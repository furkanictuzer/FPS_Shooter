using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : IState
{
    private float _checkForPlayerRadius = 3;
    public void EnterState(EnemyController enemy)
    {
        enemy.EnemyAnimatorController.PlayWalking();
        enemy.SetState(StateType.Walking);
    }

    public void UpdateState(EnemyController enemy)
    {
        enemy.MoveToTarget();
        enemy.CheckForTarget();
        enemy.CheckForAttack();
    }

    public void ExitState(EnemyController enemy)
    {
    }
    
}
