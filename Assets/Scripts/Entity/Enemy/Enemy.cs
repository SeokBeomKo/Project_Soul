using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    abstract public class Enemy : Entity, IObserver, IDamageable
    {
        [SerializeField]    public EnemyStateMachine   stateMachine;

        [SerializeField]    public Animator             enemyAnimator;
        [SerializeField]    public string               curAnimation;


        private void Awake()
        {
            targetPosition = transform.parent.position;
        }

        private void Start() 
        {
        }

        // 오브젝트 풀에서 가져올 시 초기화
        private void OnEnable() 
        {
            
        }

        public void ChangeAnimation(string newAnimation)
        {
            if(curAnimation == newAnimation)    return;

            enemyAnimator.Play(newAnimation);

            curAnimation = newAnimation;
        }

        private void Update()
        {
            if (null != stateMachine.curState)
            {
                stateMachine.curState.Execute();
            }
        }

        public void Notify()
        {
            InRange();
        }

        abstract public void Idle();
        abstract public void Moving();
        abstract public void Battle();
        abstract public void Attack();
        abstract public void Skill();
        public void InRange()
        {
            if (Vector3.Distance(GameManager.Instance.player.transform.parent.position, transform.parent.position) <= attackRange)
            {
                attackTarget = GameManager.Instance.player.transform.parent.gameObject;
                stateMachine.ChangeState(EnemyStateEnums.Attack);
            }
            else
            {
                attackTarget = null;
                stateMachine.ChangeState(EnemyStateEnums.Idle);
            }
        }
        public void Dead()
        {
            if (enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
            {
                // TODO :사망
                transform.gameObject.SetActive(false);
            }
        }

        public override IEnumerator Damaged(float _damage, float _ignore)
        {
            stateMachine.stateDic.TryGetValue(EnemyStateEnums.Idle, out IEnemyState newState);
            if (newState == stateMachine.curState)
            {
                stateMachine.ChangeState(EnemyStateEnums.Battle);
            }

            // 피격

            yield return WaitForSecondsPool.GetWaitForSeconds(0.1f);
            
            // 피격 후

            if (curHP <= 0)
            {
                stateMachine.ChangeState(EnemyStateEnums.Dead);
            }
        }
    }
}

