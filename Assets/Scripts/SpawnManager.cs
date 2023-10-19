using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public List<SpawnPointData> spawnPointDataList = new List<SpawnPointData>();

    public GameObject playerPrefab;
    public SpawnPointData playerspawn;
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
        if (spawnPointIndex >= 0 && spawnPointIndex < spawnPointDataList.Count)
        {
            SpawnPointData spawnPointData = spawnPointDataList[spawnPointIndex];
            Vector3 spawnPosition = spawnPointData.spawnPosition;
            Quaternion spawnRotation = spawnPointData.spawnRotation;

            if (currentPlayer != null)
            {
                Destroy(currentPlayer);
            }
            playerspawn = spawnPointData;
            currentPlayer = Instantiate(playerPrefab, spawnPosition, spawnRotation);
        }
    }
}