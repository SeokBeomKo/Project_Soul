using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingState : IEnemyState
{
    public Enemy enemy {get; set;}
    public EnemyStateMachine stateMachine {get; set;}
    public void Init(EnemyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        enemy = stateMachine.enemy;
    }
    public void Execute()
    {
        
    }

    public void OnStateEnter()
    {

    }
    public void OnStateExit()
    {

    }
}
