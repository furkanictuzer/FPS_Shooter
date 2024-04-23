using UnityEngine;

public class Player : DamageableObject
{
    [SerializeField] private PlayerInputController playerInputController;
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private PlayerRotationController playerRotationController;
    [SerializeField] private GroundController groundController;
    [SerializeField] private PlayerFiringController playerFiringController;
    [SerializeField] private PlayerCollectController playerCollectController;
    [SerializeField] private PlayerLevelController playerLevelController;
    public PlayerInputController PlayerInputController => playerInputController;
    public PlayerMovementController PlayerMovementController => playerMovementController;
    public PlayerRotationController PlayerRotationController => playerRotationController;
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
        HpPercentChanged += SetHpBar;
        OnDead += Fail;
    }

    private void OnDisable()
    {
        HpPercentChanged -= SetHpBar;
        OnDead -= Fail;
    }

    private void Fail()
    {
        EventManager.OnLevelFailed();
    }

    private void SetHpBar()
    {
        float percent = (float)CurrentHp / maxHp;

        UIManager.instance.SetPlayerHp(percent);
    }
    
    public void EnableInput()
    {
        PlayerMovementController.EnableMove();
        PlayerRotationController.EnableRotate();
    }

    public void DisableInput()
    {
        PlayerMovementController.DisableMove();
        PlayerRotationController.DisableRotate();
    }
}
