using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Singleton<InputController>
{
    [SerializeField] private KeyCode reloadKeyCode = KeyCode.R;
    [SerializeField] private KeyCode sprintKeyCode = KeyCode.LeftShift;
    public event Action OnJumpPressed;
    public event Action OnReloadStarted;
    public event Action OnShootingStarted;
    public event Action OnShootingStopped;

    public event Action OnSprintStarted;
    public event Action OnSprintStopped; 
    
    private void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            OnJumpPressed?.Invoke();
            Debug.Log("Jump");
        }
        
        //Fire button down
        if (Input.GetButtonDown("Fire1"))
        {
            OnShootingStarted?.Invoke();
            Debug.Log("Firing Started");
        }
        //Fire button up
        if (Input.GetButtonUp("Fire1"))
        {
            OnShootingStopped?.Invoke();
            Debug.Log("Firing Stopped");
        }

        //Sprint button down
        if (Input.GetKeyDown(sprintKeyCode))
        {
            OnSprintStarted?.Invoke();
            Debug.Log("Sprint Started");
        }
        //Sprint button up
        if (Input.GetKeyDown(sprintKeyCode))
        {
            OnSprintStopped?.Invoke();
            Debug.Log("Sprint Stopped");
        }
        
        //Reload
        if (Input.GetKeyDown(reloadKeyCode))
        {
            OnReloadStarted?.Invoke();
            Debug.Log("Reload");
        }
    }
}
