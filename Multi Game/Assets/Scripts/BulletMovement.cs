using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float bulletSpeed;

    void Start()
    {
        rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, bulletSpeed);
    }

    void Update()
    {
        
    }
}
