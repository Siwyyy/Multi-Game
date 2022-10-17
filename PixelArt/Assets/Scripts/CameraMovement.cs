using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraMovement : MonoBehaviour
{

    [Space]

    public Rigidbody rb;
    public Transform tr;
    public Transform playerTr;

    [Space]

    [Range(1, 50)]
    public float camSpeed = 10f;
    [Range(1, 50)]
    public float camDistance = 10f;
    [Range(1, 20)]
    public float camHeight = 10f;

    [Space]
    private Vector3 targetPosition;
    private Vector3 distance;

    private Quaternion targetRotation;
    


    private void Update()
    {
        targetPosition = playerTr.position + playerTr.forward * -camDistance + new Vector3(0, camHeight, 0);
        distance = targetPosition - rb.position;

        transform.rotation = Quaternion.LookRotation(playerTr.position - transform.position);
    }

    void FixedUpdate()
    {
        rb.velocity = distance * camSpeed;
    }
}
