using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public List<Transform> spawnPoints = new List<Transform>();

    public GameObject playerPrefab;

    private GameObject currentPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SpawnPlayer(0);
    }
    public void SpawnPlayer(int spawnPointIndex)
    {
        if (spawnPointIndex >= 0 && spawnPointIndex < spawnPoints.Count)
        {
            Transform spawnPoint = spawnPoints[spawnPointIndex];

            // ���� �÷��̾ �����ϸ� ��Ʈ����
            if (currentPlayer != null)
            {
                Destroy(currentPlayer);
            }

            // ���ο� �÷��̾� ����
            currentPlayer = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}