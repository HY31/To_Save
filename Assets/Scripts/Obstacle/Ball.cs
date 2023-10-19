using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyBall), 5f);
    }
    
    void DestroyBall()
    {
        Destroy(gameObject);
    }
}
