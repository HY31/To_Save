using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sound 
{
    public string soundName;
    public AudioClip audioClip;
}

public class SoundManager : MonoBehaviour
{
    public GameObject BgmMixer;
    public GameObject SfxMixer;

    public static SoundManager Instance;

    [Header("사운드 등록")]
    public Sound[] bgmSounds;
    public Sound[] sfxSounds;

    [Header("브금 플레이어")]
    public AudioSource[] bgmPlayer;

    [Header("효과음 플레이어")]
    public AudioSource[] sfxPlayer;

    private Dictionary<string, AudioClip> soundDictionary = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

        BgmMixer.GetComponent<Slider>().onValueChanged.AddListener(SetBgmVolume);
        SfxMixer.GetComponent<Slider>().onValueChanged.AddListener(setSfxVolume);

        foreach (Sound sound in bgmSounds)
        {
            soundDictionary[sound.soundName] = sound.audioClip;
        }
        foreach (Sound sound in sfxSounds)
        {
            soundDictionary[sound.soundName] = sound.audioClip;
        }
    }

    void Start()
    {
        PlayBgm("BackGroundMusic");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaySE("Click");
        }
    }

    public void PlayBgm(string soundName) 
    {
        if (soundDictionary.ContainsKey(soundName))
        {
            AudioClip soundClip = soundDictionary[soundName];
            foreach (AudioSource player in bgmPlayer) 
            {
                player.clip = soundClip;
                player.Play();
            }

        }
    }
    public void PlaySE(string soundName)
    {
        for (int i = 0; i < sfxSounds.Length; i++) 
        {
            if (soundName == sfxSounds[i].soundName) 
            {
                for (int j = 0; j < sfxPlayer.Length; j++) 
                {
                    if (!sfxPlayer[j].isPlaying) 
                    {
                        sfxPlayer[j].clip = sfxSounds[i].audioClip;
                        sfxPlayer[j].Play();

                        return;
                    }
                }
                return;
            }
 
        }
    }

    public void SetBgmVolume(float value)
    {
        foreach (AudioSource player in bgmPlayer)
        {
            player.volume = value;
        }
    }
    public void setSfxVolume(float value)
    {
        foreach (AudioSource player in sfxPlayer)
        {
            player.volume = value;
        }
    }

}
