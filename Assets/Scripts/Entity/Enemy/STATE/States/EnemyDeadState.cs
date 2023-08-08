using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyDeadState : IEnemyState
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
            enemy.Dead();
        }

        public void OnStateEnter()
        {
            enemy.ChangeAnimation(EnemyStateEnums.Dead.ToString());
        }
        public void OnStateExit()
        {

        }
    }
    
}
