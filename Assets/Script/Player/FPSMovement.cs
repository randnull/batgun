using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float _speed = 500.0f;
    public float _gravity = -9.8f;
    public CharacterController _controller;

    public void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
        {
            Debug.LogError("Character controller not found");
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = Vector3.ClampMagnitude(movement, _speed);
        movement.y = _gravity;
        movement *= Time.deltaTime;
        
        movement = transform.TransformDirection(movement);
        _controller.Move(movement);
    }
}
