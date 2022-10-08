using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraMovement : MonoBehaviour
{

    [Space]

    public Rigidbody rb;
    public Transform tr;
    public Transform playerTr;

    [Space]

    public float camSpeed = 3f;
    public float camHeight = 11f;
    public Quaternion camAngle = new Quaternion(40, 0, 0, 0);

    [Space]
    private Vector3 targetPosition;
    private Vector3 distance;

    private Quaternion targetRotation;
    


    private void Update()
    {
        targetPosition = playerTr.position + playerTr.forward * -10 + new Vector3(0, camHeight, 0);
        distance = targetPosition - rb.position;

        transform.rotation = Quaternion.LookRotation(playerTr.position - transform.position);

        //targetRotation = playerTr.rotation;
        //targetRotation.x = 40;
        //transform.RotateAround(playerTr.position, new Vector3(0, 1, 0), 0.1f);
        //Debug.Log(transform.rotation);
    }

    void FixedUpdate()
    {
        rb.velocity = distance * camSpeed;
    }
}
