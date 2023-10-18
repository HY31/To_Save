using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    private Vector3 checkPoint;

    private void Awake()
    {
        checkPoint = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Revive();
        }
    }

    public void OnCheckPoint(Vector3 position)
    {
        checkPoint = position;
    }

    private void Revive()
    {
        transform.position = checkPoint;
    }
}
