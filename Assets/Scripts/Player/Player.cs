using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DamageableObject
{
    [SerializeField] private PlayerInputController playerInputController;
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private PlayerGroundController groundController;
    [SerializeField] private PlayerFiringController playerFiringController;
    [SerializeField] private PlayerCollectController playerCollectController;
    public PlayerInputController PlayerInputController => playerInputController;
    public PlayerMovementController PlayerMovementController => playerMovementController;
    public PlayerGroundController GroundController => groundController;
    public PlayerFiringController PlayerFiringController => playerFiringController;
    public PlayerCollectController PlayerCollectController => playerCollectController;

    private void Start()
    {
        SetHpBar();
    }

    private void OnEnable()
    {
        OnTakeDamage += SetHpBar;
    }

    private void OnDisable()
    {
        OnTakeDamage -= SetHpBar;
    }

    private void SetHpBar()
    {
        float percent = (float)CurrentHp / maxHp;

        HPBarController.instance.SetPercent(percent);
    }
}
