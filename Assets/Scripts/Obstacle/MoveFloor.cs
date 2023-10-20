using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    float initPositionY;
    float initPositionZ;
    public float distance;
    public float turningPoint;

    public bool turnSwitch;
    public float moveSpeed;


    public float rotateSpeed;

    void Awake()
    {
        if (gameObject.name == "UD_Floor")
        {
            initPositionY = transform.position.y;
            turningPoint = initPositionY - distance;
        }
        if (gameObject.name == "LR_Floor")
        {
            initPositionZ = transform.position.z;
            turningPoint = initPositionZ - distance;
        }
    }

    void upDown()
    {
        float currentPositionY = transform.position.y;

        if (currentPositionY >= initPositionY)
        {
            turnSwitch = false;
        }
        else if (currentPositionY <= turningPoint)
        {
            turnSwitch = true;
        }

        if (turnSwitch)
        {
            transform.position = transform.position + new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime;
        }
    }
    void rotate()
    {
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }
    void leftRight()
    {

        float currentPositionZ = transform.position.z;

        if (currentPositionZ >= initPositionZ + distance)
        {
            turnSwitch = false;
        }
        else if (currentPositionZ <= turningPoint)
        {
            turnSwitch = true;
        }

        if (turnSwitch)
        {
            transform.position = transform.position + new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime;
        }

    }

    void Update()
    {
        if (gameObject.name == "UD_Floor")
        {
            upDown();
        }
        if (gameObject.name == "RT_Floor")
        {
            rotate();
        }
        if (gameObject.name == "LR_Floor")
        {
            leftRight();
        }

    }
}
