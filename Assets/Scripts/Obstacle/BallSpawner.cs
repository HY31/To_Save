using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject Ball;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BallSpawn");
        
    }

    IEnumerator BallSpawn()
    {
        while (true)
        {
            var ball = Instantiate(Ball);
            ball.transform.position = transform.position;
            yield return new WaitForSeconds(9f);
        }
    }

}
