using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    public void EnterState(EnemyController enemy)
    {
        enemy.EnemyAnimatorController.PlayDie();
        enemy.SetState(StateType.Die);
    }

    public void ExitState(EnemyController enemy)
    {
        
    }

    public void UpdateState(EnemyController enemy)
    {
        
    }
}
