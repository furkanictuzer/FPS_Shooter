using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private KeyCode reloadKeyCode = KeyCode.R;
    [SerializeField] private KeyCode sprintKeyCode = KeyCode.LeftShift;

    [SerializeField] private bool canGetInput = true;

    #region Events

    public event Action OnJumpPressed;
    public event Action OnReloadStarted;
    public event Action ShootingStarted;
    public event Action ShootingStopped;

    public event Action OnSprintStarted;
    public event Action OnSprintStopped; 

    #endregion
    
    private void Update()
    {
        if (!canGetInput) return;
        
        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            OnJumpPressed?.Invoke();
            Debug.Log("Jump");
        }
        
        //Fire button down
        if (Input.GetMouseButton(0))
        {
            ShootingStarted?.Invoke();
            Debug.Log("Firing Started");
        }
        //Fire button up
        if (Input.GetMouseButton(0))
        {
            OnShootingStopped();
        }

        //Sprint button down
        if (Input.GetKeyDown(sprintKeyCode))
        {
            OnSprintStarted?.Invoke();
            Debug.Log("Sprint Started");
        }
        //Sprint button up
        if (Input.GetKeyUp(sprintKeyCode))
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

    public void CloseInput()
    {
        canGetInput = false;
    }

    public void OpenInput()
    {
        canGetInput = true;
    }

    public void OnShootingStopped()
    {
        ShootingStopped?.Invoke();
        Debug.Log("Firing Stopped");
    }
}
