using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DamageableObject
{
    [SerializeField] private PlayerInputController playerInputController;
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private GroundController groundController;
    [SerializeField] private PlayerFiringController playerFiringController;
    [SerializeField] private PlayerCollectController playerCollectController;
    [SerializeField] private PlayerLevelController playerLevelController;
    public PlayerInputController PlayerInputController => playerInputController;
    public PlayerMovementController PlayerMovementController => playerMovementController;
    public GroundController GroundController => groundController;
    public PlayerFiringController PlayerFiringController => playerFiringController;
    public PlayerCollectController PlayerCollectController => playerCollectController;
    public PlayerLevelController PlayerLevelController => playerLevelController;

    private void Start()
    {
        SetHpBar();
    }

    private void OnEnable()
    {
        HpAmountChanged += SetHpBar;
    }

    private void OnDisable()
    {
        HpAmountChanged -= SetHpBar;
    }

    private void SetHpBar()
    {
        float percent = (float)CurrentHp / maxHp;

        UIManager.instance.SetPlayerHp(percent);
    }
}
