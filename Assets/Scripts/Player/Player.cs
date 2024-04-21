using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DamageableObject
{
    [SerializeField] private PlayerInputController playerInputController;
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private PlayerGroundController groundController;
    [SerializeField] private PlayerFiringController playerFiringController;

    public PlayerInputController PlayerInputController => playerInputController;
    public PlayerMovementController PlayerMovementController => playerMovementController;
    public PlayerGroundController GroundController => groundController;
    public PlayerFiringController PlayerFiringController => playerFiringController;
}
