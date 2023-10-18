using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destinationSceneName; // �̵��� ��� ���� �̸�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾���� �浹�� �����ϸ�
        {
            // ��� ������ �̵�
            SceneManager.LoadScene(destinationSceneName);
        }
    }
}
