using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destinationSceneName; // 이동할 대상 씬의 이름

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어와의 충돌을 감지하면
        {
            // 대상 씬으로 이동
            SceneManager.LoadScene(destinationSceneName);
        }
    }
}
