using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTarget : MonoBehaviour
{
    [SerializeField] private GameObject endingCredit;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endingCredit.SetActive(true);
            _audio.Play();
        }
    }
}
