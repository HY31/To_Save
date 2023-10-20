using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destinationSceneName; // 이동할 대상 씬의 이름
    public int index;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            SpawnManager.Instance.targetSpawnPointIndex = index;
            SceneManager.LoadScene(destinationSceneName);
        }
    }
}
