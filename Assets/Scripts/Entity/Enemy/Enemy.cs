using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    abstract public class Enemy : Entity, IObserver
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
        abstract public void Attack();
        abstract public void Skill();
        public void InRange()
        {
            if (Vector3.Distance(GameManager.Instance.player.transform.position, transform.parent.position) <= attackRange)
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

        }

        public override IEnumerator Damaged()
        {
            yield return WaitForSecondsPool.GetWaitForSeconds(0.1f);
        }
    }
}

