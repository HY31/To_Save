using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance;
    public GameObject Player;

    public GameObject endingUI;

    private void Awake()
    {
        Instance = this;
    }

    public void GameEnd()
    {
        endingUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
