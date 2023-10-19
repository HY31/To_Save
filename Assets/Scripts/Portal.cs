using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destinationSceneName; // �̵��� ��� ���� �̸�
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

            // ��� ������ �̵�
            SceneManager.LoadScene(destinationSceneName);
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ��� ���� �ε�� �� ������ ����
        if (scene.isLoaded)
        {
            SpawnManager.Instance.SpawnPlayer(spawnPointIndex);
        }
    }
}
