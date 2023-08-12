using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyEliteType : Enemy
    {
        public override void Idle()
        {

        }
        public override void Moving()
        {

        }

        public override void Battle()
        {
            
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
