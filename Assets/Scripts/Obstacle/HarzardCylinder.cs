using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarzardCylinder : MonoBehaviour
{
    float rotateSpeed;
    private void Awake()
    {
        rotateSpeed = 300f;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,rotateSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(100);
        }
    }
}
