using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private float speed = 10f;
    private float gravity = -9.81f;
    private Vector3 velocity;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * speed * Time.deltaTime);

        if(_controller.isGrounded && velocity.y < 0) velocity.y = 0;
        velocity.y += gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime); 
    }
}
