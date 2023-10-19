using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{

    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text contentText;

    [SerializeField] private Button BackBtn;
    [SerializeField] private Button confirmBtn;
    [SerializeField] private Button cancelBtn;

    private Action OnConfirm;

    void Start()
    { 
        confirmBtn.onClick.AddListener(Confirm);
        cancelBtn.onClick.AddListener(Close);
        BackBtn.onClick.AddListener(Close);
    }

    public void SetPopup(string title, string content, Action onConfirm = null)
    {
        titleText.text = title;
        contentText.text = content;

        OnConfirm = onConfirm;
    }

    void Confirm()
    {
        if (OnConfirm != null)
        {
            OnConfirm.Invoke();
        }

        Close();
    }

 

    void Close()
    {
        gameObject.SetActive(false);
    }
}
