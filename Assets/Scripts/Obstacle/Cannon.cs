using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        while (true) 
        {
            Bullet bullet = ObjectPool.Instance.GetObject();
            bullet.transform.rotation = transform.rotation;
            bullet.transform.position = transform.position;
            yield return new WaitForSeconds(5f);
        }
    }
}
