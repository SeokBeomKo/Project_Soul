using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    abstract public class Enemy : Entity, IObserver, IDamageable
    {
        [SerializeField]    public EnemyData            enemyData;
        [SerializeField]    public EnemyStateMachine    stateMachine;

        [SerializeField]    public Animator             enemyAnimator;
        [SerializeField]    public string               curAnimation;

        [SerializeField]    public HitEffectController  hitEffectController;

        [SerializeField]    public GameObject           attVFX;


        private void Awake()
        {
            moveTarget = transform.parent.position;
            entityInfo = enemyData.enemyInfo;
        }

        private void Start() 
        {
            entityInfo.hpCur = entityInfo.hpMax;
        }

        // 오브젝트 풀에서 가져올 시 초기화
        private void OnEnable() 
        {
            entityInfo.hpCur = entityInfo.hpMax;
        }

        void OnDisable()
        {
            if (GameManager.Instance.nodeMap.ContainsKey(new Vector2(transform.position.x,transform.position.z)))
            {
                GameManager.Instance.SetWalkable(new Vector2(transform.position.x,transform.position.z), true);
            }
            stateMachine.ChangeState(EnemyStateEnums.Idle);
        }

        private void Enenmy_OnMapLoaded()
        {
            // 맵 로딩이 완료된 후에 실행할 로직
            GameManager.Instance.SetWalkable(new Vector2(transform.position.x,transform.position.y), false);
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

        public abstract void Idle();
        public abstract void Moving();
        public abstract void Battle();
        public abstract void Attack();
        public abstract void OnAttack();
        public abstract void OffAttack();
        public abstract void Skill();
        public void InRange()
        {
            if (Vector3.Distance(GameManager.Instance.player.transform.parent.position, transform.parent.position) <= entityInfo.attRange)
            {
                attackTarget = GameManager.Instance.player.GetComponent<Entity>();
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
            if (enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f &&
                enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
            {
                transform.parent.gameObject.SetActive(false);
            }
        }

        public override void Hit(float _damage, float _ignore)
        {
            float m_ftDamage = _damage - (entityInfo.defPower - _ignore);
            if (entityInfo.hpCur <= m_ftDamage)
            {
                entityInfo.hpCur = 0f;
                stateMachine.ChangeState(EnemyStateEnums.Dead);
                return;
            }

            stateMachine.stateDic.TryGetValue(EnemyStateEnums.Idle, out IEnemyState newState);
            if (newState == stateMachine.curState)
            {
                stateMachine.ChangeState(EnemyStateEnums.Battle);
            }

            entityInfo.hpCur -= m_ftDamage;
            NotifyObservers();
            hitEffectController.ApplyHitEffect();
        }
    }
}

