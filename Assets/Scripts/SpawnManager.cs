using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public List<SpawnPointData> spawnPointDataList = new List<SpawnPointData>();

    public GameObject playerPrefab;
    public SpawnPointData playerspawn;
    public int targetSpawnPointIndex;

    [field: SerializeField] public CinemachineVirtualCamera vCam;

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
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.isLoaded)
        {
            SpawnPlayer(targetSpawnPointIndex);
        }

        Player player = currentPlayer.GetComponent<Player>();
        vCam.Follow = player.cameraLookPoint;
        vCam.LookAt = player.cameraLookPoint;
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