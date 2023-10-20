using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destinationSceneName; // �̵��� ��� ���� �̸�
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
