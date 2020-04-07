﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotateSpeed = 3.0f;
    public float jumpForce = 15.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        // simple movement w/o jumping
        CharacterController controller = GetComponent<CharacterController>();

        /*transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // which way is our nose pointing?
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = Input.GetAxis("Vertical") * speed;
        controller.SimpleMove(forward * curSpeed);*/

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }
}