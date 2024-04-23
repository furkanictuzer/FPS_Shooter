using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    
    private bool _canRotate = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void OnEnable()
    {
        EventManager.GameStarted += EnableRotate;
        EventManager.LevelFailed += DisableRotate;
    }

    private void OnDisable()
    {
        EventManager.GameStarted += EnableRotate;
        EventManager.LevelFailed -= DisableRotate;
    }

    private void Update()
    {
        if (!_canRotate) return;
        
        Rotate();
    }
    
    public void EnableRotate()
    {
        _canRotate = true;
    }

    public void DisableRotate()
    {
        _canRotate = false;
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
