using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyIdleState : IEnemyState
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
            enemy.Idle();
        }

        public void OnStateEnter()
        {
            enemy.ChangeAnimation(EnemyStateEnums.Idle.ToString());
        }
        public void OnStateExit()
        {

        }
    }
    
}
