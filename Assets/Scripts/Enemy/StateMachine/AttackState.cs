using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    public void EnterState(EnemyController enemy)
    {
        enemy.EnemyAnimatorController.PlayAttack();
        enemy.SetState(StateType.Attack);
        Debug.Log("Entering Attacking State.");
    }

    public void UpdateState(EnemyController enemy)
    {
        enemy.CheckForAttack();
    }

    public void ExitState(EnemyController enemy)
    {
        Debug.Log("Exiting Attacking State.");
    }
}
