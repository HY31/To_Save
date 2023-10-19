using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destinationSceneName; // �̵��� ��� ���� �̸�
    public int spawnPointIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);

            // ��� ������ �̵�
            SceneManager.LoadScene(destinationSceneName);
            SpawnManager.Instance.SpawnPlayer(spawnPointIndex);
        }
    }
}
