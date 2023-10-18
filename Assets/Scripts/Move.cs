using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;
    private Vector3 direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        direction = direction.normalized * speed;
        _rigidbody.velocity = direction;
    }
}
