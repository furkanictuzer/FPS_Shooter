using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : IState
{
    public void EnterState(EnemyController enemy)
    {
        enemy.EnemyAnimatorController.PlayDie();
        enemy.SetState(StateType.Die);
        Debug.Log("Entering Die State.");
    }

    public void ExitState(EnemyController enemy)
    {
        
    }

    public void UpdateState(EnemyController enemy)
    {
        Debug.Log("Exiting Die State.");
    }
}
