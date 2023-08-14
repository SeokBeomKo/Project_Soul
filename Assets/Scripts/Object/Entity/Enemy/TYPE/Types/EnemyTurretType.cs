using System.Collections;
using System.Collections.Generic;
using MagicaCloth2;
using UnityEngine;
using UnityEngine.Pool;

namespace EnemySystem
{
    public class EnemyTurretType : Enemy
    {
        public string projectileName;
        void Shot()
        {
            PoolManager.Instance.SpawnFromPool(projectileName,attProjectilePos.position,transform.rotation);
        }
        public override void Idle()
        {

        }
        public override void Moving()
        {

        }

        public override void Watch()
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
            attackTarget.GetComponent<Entity>().Hit(entityInfo.attDamage,entityInfo.ignPower);
            attParticle.Play();
            PoolManager.Instance.SpawnFromPool(projectileName,attProjectilePos.position,transform.rotation);
        }

        public override void Skill()
        {

        }

        public override void OnBattle()
        {
        }

        public override void OffBattle()
        {
        }
    }
}
