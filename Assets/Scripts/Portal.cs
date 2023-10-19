using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destinationSceneName; // 이동할 대상 씬의 이름
    public int spawnPointIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);

            // 대상 씬으로 이동
            SceneManager.LoadScene(destinationSceneName);
            SpawnManager.Instance.SpawnPlayer(spawnPointIndex);
        }
    }
}
