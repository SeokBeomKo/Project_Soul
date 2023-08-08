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
            enemy.transform.parent.LookAt(new Vector3(enemy.attackTarget.transform.position.x,0,enemy.attackTarget.transform.position.z));
            enemy.ChangeAnimation(EnemyStateEnums.Attack.ToString());
        }
        public void OnStateExit()
        {

        }
    }
    
}
