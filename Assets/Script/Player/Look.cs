using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public enum RotationAxis
    {
        XandY,
        X,
        Y
    }
    
    public RotationAxis _axis = RotationAxis.XandY;
    public float _rotationspeedHor = 5.0f;
    public float _rotationspeedVer = 5.0f;
    
    public float maxVerticalAngle = 45.0f;
    public float minVerticalAngle = -45.0f;
    
    private float _rotationX = 0.0f;

    public void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    public void Update()
    {
        if (_axis == RotationAxis.XandY)
        {
            _rotationX += Input.GetAxis("Mouse Y") * _rotationspeedVer;
            _rotationX = Mathf.Clamp(_rotationX, minVerticalAngle, maxVerticalAngle);
            
            
            float detla = Input.GetAxis("Mouse X") * _rotationspeedHor;
            float _rotationY = transform.localEulerAngles.y + detla;
            
            
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0.0f);
        } else if (_axis == RotationAxis.X)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _rotationspeedHor, 0);
        } else if (_axis == RotationAxis.Y)
        {
            _rotationX += Input.GetAxis("Mouse Y") * _rotationspeedVer;
            _rotationX = Mathf.Clamp(_rotationX, minVerticalAngle, maxVerticalAngle);

            float rotationY = transform.localEulerAngles.y;
            
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
