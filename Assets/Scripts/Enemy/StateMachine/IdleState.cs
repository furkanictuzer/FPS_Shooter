using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private const float MaxIdleRemainingTime = 2;
    public float _timer;
    
    public void EnterState(EnemyController enemy)
    {
        enemy.EnemyAnimatorController.PlayIdle();
        enemy.SetState(StateType.Idle);
    }

    public void UpdateState(EnemyController enemy)
    {
        if (_timer < MaxIdleRemainingTime)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            enemy.ChangeState(new WalkingState());
        }
        
    }

    public void ExitState(EnemyController enemy)
    {
        _timer = 0;
    }
}
