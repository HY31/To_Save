using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed = 1f;
    public Rigidbody Rigidbody;


    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        DestoryBulletInvoke();
        
    }
    private void Update()
    {
        Rigidbody.AddForce(-transform.forward * speed);
    }
    public void DestoryBulletInvoke()//³«ÇÏ ´ë±â
    {
        Invoke(nameof(DestroyBullet), 3f);
        SoundManager.Instance.PlaySE("BulletSound");
    }
    private void DestroyBullet()//³«ÇÏ
    {
        //StartCoroutine("DelayFallBullet");
        //Rigidbody.useGravity = false;
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.rotation = Quaternion.identity;
        ObjectPool.Instance.ReturnObj(this);
        
    }

    //IEnumerator DelayFallBullet()
    //{
    //    Rigidbody.useGravity = true;
    //    yield return new WaitForSeconds(0.5f);
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(100);
        }
    }

}
