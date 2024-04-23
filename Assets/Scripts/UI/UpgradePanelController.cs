using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradePanelController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private KeyCode openCloseKey = KeyCode.Tab;

    [SerializeField] private List<UpgradeButtonController> buttons = new List<UpgradeButtonController>();

    private bool _isOpen;
    
    private void Start()
    {
        Deactivate();
        
        InitializeAllUpgradeButton();
    }

    private void Update()
    {
        if (Input.GetKeyDown(openCloseKey))
        {
            Pressed();
        }
    }
    
    private void InitializeAllUpgradeButton()
    {
        foreach (var button in buttons)
        {
            button.Initialize();
        }
    }

    private void Pressed()
    {
        Player player = LevelController.instance.currentPlayer;
        
        if (_isOpen)
        {
            player?.PlayerInputController.OpenInput();
            Deactivate();
        }
        else
        {
            player?.PlayerInputController.CloseInput();
            Activate();
        }
    }

    private void Activate()
    {
        Cursor.lockState = CursorLockMode.None;
        LevelController.instance.DisableInput();
        _isOpen = true;
        panel.SetActive(true);
    }
    
    private void Deactivate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        LevelController.instance.EnableInput();
        _isOpen = false;
        panel.SetActive(false);
    }
}
