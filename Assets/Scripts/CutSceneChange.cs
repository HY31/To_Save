using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneChange : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("JGScene");
    }
}