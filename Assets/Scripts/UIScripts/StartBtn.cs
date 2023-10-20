using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    public Button startBtn;

    
    
    void Start()
    {
        startBtn.onClick.AddListener(StartScene);
    }

   void StartScene() 
    {
        SceneManager.LoadScene("CutScene_1");
    }
}
