using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnPointData", menuName = "SpawnPointData", order = 1)]
public class SpawnPointData : ScriptableObject
{
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;
}
