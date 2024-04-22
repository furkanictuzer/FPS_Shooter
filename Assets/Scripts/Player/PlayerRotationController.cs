using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    [SerializeField] private GameObject camObj;
    [SerializeField] 
    private float mouseSensitivity=500;
    [Space]
    [SerializeField] private float topClamp = -90;
    [SerializeField] private float bottomClamp = 90;
    
    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _yRotation += mouseX;
        
        //Clamping
        _xRotation = Mathf.Clamp(_xRotation, topClamp, bottomClamp);
        
        camObj.transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
    }
}
