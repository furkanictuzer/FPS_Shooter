using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle,
    Walking,
    Attack,
    Die
}

public interface IState
{
    void EnterState(EnemyController enemy);
    void ExitState(EnemyController enemy);
    void UpdateState(EnemyController enemy);
}
