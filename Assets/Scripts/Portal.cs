using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destinationSceneName; // 이동할 대상 씬의 이름
    public int spawnPointIndex;
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);

            // 대상 씬으로 이동
            SceneManager.LoadScene(destinationSceneName);
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 모든 씬이 로드될 때 실행할 동작
        if (scene.isLoaded)
        {
            SpawnManager.Instance.SpawnPlayer(spawnPointIndex);
        }
    }
}
