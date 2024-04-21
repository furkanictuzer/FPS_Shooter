using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerFpsAnimatorContorller : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Animator fpsAnimator;
    
    private static readonly int Shoot = Animator.StringToHash("Shoot");
    private static readonly int Shooting = Animator.StringToHash("Shooting");
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int ReloadHash = Animator.StringToHash("Reload");
    private static readonly int IsGrounded = Animator.StringToHash("isGrounded");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private void Awake()
    {
        if (player == null)
        {
            player = GetComponentInParent<Player>();
        }
    }

    private void OnEnable()
    {
        player.PlayerInputController.ShootingStarted += ShootingStarted;
        player.PlayerInputController.ShootingStopped += ShootingStopped;
        player.PlayerInputController.OnReloadStarted += ReloadStarted;
        
        player.PlayerMovementController.IsMovingChanged += SetIsMoving;
    }

    private void OnDisable()
    {
        player.PlayerInputController.ShootingStarted -= ShootingStarted;
        player.PlayerInputController.ShootingStopped -= ShootingStopped;
        player.PlayerInputController.OnReloadStarted -= ReloadStarted;
        
        player.PlayerMovementController.IsMovingChanged -= SetIsMoving;
    }

    private void Update()
    {
        if (player.PlayerMovementController != null)
        {
            SetSpeed(player.PlayerMovementController.Speed);
        }

        if (player.GroundController != null)
        {
            SetOnGroundedBoolean(player.GroundController.IsGrounded);
        }
    }
    
    private void ReloadStarted()
    {
        if (!player.PlayerFiringController.CanReload)
        {
            return;
        }
        
        ReloadTrigger();
    }

    private void ShootingStarted()
    {
        if (!player.PlayerFiringController.HasAmmo)
        {
            return;
        }
        
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
        fpsAnimator.SetBool(IsGrounded, grounded);
    }
    
    private void SetShootingBoolean(bool isShooting)
    {
        fpsAnimator.SetBool(Shooting, isShooting);
    }

    private void ReloadTrigger()
    {
        fpsAnimator.SetTrigger(ReloadHash);
    }

    private void ShootTrigger()
    {
        fpsAnimator.SetTrigger(Shoot);
    }

    public void Fire()
    {
        if (player.PlayerFiringController.HasAmmo)
        {
            player.PlayerFiringController.Fire();
        }
        else
        {
            player.PlayerInputController.OnShootingStopped();
        }
    }

    public void Reload()
    {
        player.PlayerFiringController.Reload();
    }
}
