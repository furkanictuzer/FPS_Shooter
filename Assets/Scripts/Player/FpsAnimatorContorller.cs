using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FpsAnimatorContorller : MonoBehaviour
{
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private PlayerGroundController groundController;
    [SerializeField] private Animator fpsAnimator;
    
    private static readonly int Shoot = Animator.StringToHash("Shoot");
    private static readonly int Shooting = Animator.StringToHash("Shooting");
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Reload = Animator.StringToHash("Reload");
    private static readonly int İsGrounded = Animator.StringToHash("isGrounded");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private void Start()
    {
        InputController.instance.OnShootingStarted += ShootingStarted;
        InputController.instance.OnShootingStopped += ShootingStopped;
        InputController.instance.OnReloadStarted += ReloadStarted;
        
        playerMovementController.IsMovingChanged += SetIsMoving;
    }

    private void OnDestroy()
    {
        InputController.instance.OnShootingStarted -= ShootingStarted;
        InputController.instance.OnShootingStopped -= ShootingStopped;
        InputController.instance.OnReloadStarted -= ReloadStarted;
        
        playerMovementController.IsMovingChanged -= SetIsMoving;
    }

    private void Update()
    {
        if (playerMovementController != null)
        {
            SetSpeed(playerMovementController.Speed);
        }

        if (groundController != null)
        {
            SetOnGroundedBoolean(groundController.IsGrounded);
        }
    }

    private void ReloadStarted()
    {
        ReloadTrigger();
    }

    private void ShootingStarted()
    {
        SetShootingBoolean(true);
        ShootTrigger();
    }

    private void ShootingStopped()
    {
        SetShootingBoolean(false);
    }

    private void SetIsMoving(bool isMoving)
    {
        fpsAnimator.SetBool(IsMoving, isMoving);
    }

    private void SetSpeed(float speed)
    {
        fpsAnimator.SetFloat(Speed, speed);
    }

    private void SetOnGroundedBoolean(bool grounded)
    {
        fpsAnimator.SetBool(İsGrounded, grounded);
    }
    
    private void SetShootingBoolean(bool isShooting)
    {
        fpsAnimator.SetBool(Shooting, isShooting);
    }

    private void ReloadTrigger()
    {
        fpsAnimator.SetTrigger(Reload);
    }

    private void ShootTrigger()
    {
        fpsAnimator.SetTrigger(Shoot);
    }
}
