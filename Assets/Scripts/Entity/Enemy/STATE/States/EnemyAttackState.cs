using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyAttackState : IEnemyState
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
            enemy.Attack();
        }

        public void OnStateEnter()
        {
            enemy.ChangeAnimation(EnemyStateEnums.Attack.ToString());
        }
        public void OnStateExit()
        {

        }
    }
    
}
