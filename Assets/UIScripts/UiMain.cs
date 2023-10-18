using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMain : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button rePlayBtn;
    [SerializeField] private Button volumeBtn;
    [SerializeField] private Button stageBtn;
    [SerializeField] private Button closeBtn;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Button volumeCloseBtn;

    [SerializeField] private GameObject settingPopup;
    [SerializeField] private GameObject volumePopup;

    private void Awake()
    {
        volumePopup.SetActive(false);
        settingPopup.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        playBtn.onClick.AddListener(Close);
        rePlayBtn.onClick.AddListener(OpenPopup_RePlay);
        volumeBtn.onClick.AddListener(VolumeValue);
        stageBtn.onClick.AddListener(OpenPopup_Stage);
        closeBtn.onClick.AddListener(Close);
        pauseBtn.onClick.AddListener(PauseGame);
        volumeCloseBtn.onClick.AddListener(VolumePopupClose);
    }
    void VolumeValue()
    {
        volumePopup.SetActive(true);
        settingPopup.SetActive(false);
    }

    void Close() 
    {
        volumePopup.SetActive(false);
        settingPopup.SetActive(false);    
    }
    void PauseGame() 
    {
        settingPopup.SetActive(true);
    }
    void VolumePopupClose() 
    {
        volumePopup.SetActive(false);
        settingPopup.SetActive(true);
    }

    void OpenPopup_RePlay() 
    {

        UIPopup popup = UIManager.Instance.OpenUI<UIPopup>();
        popup.SetPopup("�ٽ��ϱ�", "ó������ ���ư��ðڽ��ϱ�?", ReLoadScene);


    }
    void ReLoadScene() 
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    void OpenPopup_Stage() 
    {

        UIPopup popup = UIManager.Instance.OpenUI<UIPopup>();
        popup.SetPopup("��������", "�������� ����ȭ������ �̵��Ͻðڽ��ϱ�??", ChangeScene);
    }

    void ChangeScene() 
    {
        //SceneManager.LoadScene("SampleScene");
    }


}
