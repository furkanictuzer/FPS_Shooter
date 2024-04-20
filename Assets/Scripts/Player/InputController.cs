using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Singleton<InputController>
{
    [SerializeField] private KeyCode reloadKeyCode = KeyCode.R;
    public event Action OnJumpPressed;
    public event Action OnReloadStarted;
    public event Action OnShootingStarted;
    public event Action OnShootingStopped;
    
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnJumpPressed?.Invoke();
            Debug.Log("Jump");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            OnShootingStarted?.Invoke();
            Debug.Log("Firing Started");
        }
        
        if (Input.GetButtonUp("Fire1"))
        {
            OnShootingStopped?.Invoke();
            Debug.Log("Firing Stopped");
        }

        if (Input.GetKeyDown(reloadKeyCode))
        {
            OnReloadStarted?.Invoke();
            Debug.Log("Reload");
        }
    }
}
