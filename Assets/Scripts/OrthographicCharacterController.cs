﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicCharacterController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;

    Vector3 forward, right;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        //Detect if grounded (Physics.Raycast a set distance downwards)
        //if(grounded)
        //Set grounded value
        //else
        //Do un-grounded things
        //check if is jumping?

        if (Input.anyKey)
        {
            Move();
            //Jump
        } 

        Debug.DrawRay(transform.position, transform.forward * 2, Color.red);
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;

        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
