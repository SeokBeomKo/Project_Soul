using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyTurretType : Enemy
    {
        public override void Idle()
        {

        }
        public override void Moving()
        {

        }

        public override void Battle()
        {
            // 사거리 이내라면 공격
            if (Vector3.Distance(attackTarget.transform.position, transform.parent.position) <= entityInfo.attRange)
            {
                stateMachine.ChangeState(EnemyStateEnums.Attack);
                return;
            }
        }
        public override void Attack()
        {
            if (attackTarget.entityInfo.hpCur <= 0f)
            {
                attackTarget = null;
                stateMachine.ChangeState(EnemyStateEnums.Idle);
            }
        }
        public override void OnAttack()
        {
        }

        public override void OffAttack()
        {
        }
        public override void Skill()
        {

        }
    }
}
