using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

public class Player : Entity
{
    [SerializeField]    public PlayerStateMachine   stateMachine;
    [SerializeField]    public PlayerType           soul;

    [SerializeField]    public Animator             playerAnimator;
    [SerializeField]    public string               curAnimation;

    [SerializeField]    public PlayerArea           playerArea;

    [HideInInspector]   public LayerMask            clickableLayers;

    [SerializeField]    public PlayerVFX            playerVFX;


    private void Awake()
    {
        clickableLayers = ~(1 << LayerMask.NameToLayer("Area"));
        moveTarget = transform.parent.position;
        soul.player = this;

        entityInfo.name = "player";     // 이름
        entityInfo.moveSpeed = 2f;  // 이동 속도
    
        entityInfo.hpMax = 100;      // 최대 체력
        entityInfo.attRange = 4;   // 공격 사거리
        entityInfo.attSpeed = 1;   // 공격 속도
    }

    private void Start() 
    {
        entityInfo.hpCur = entityInfo.hpMax;      // 현재 체력
    
        entityInfo.attDamage = 10;  // 공격력
    
        entityInfo.defPower = 0;   // 방어력
        entityInfo.ignPower = 0;   // 관통력
    }

    // 오브젝트 풀에서 가져올 시 초기화
    void OnEnable() 
    {
        tilePosition = new(transform.position.x,transform.position.z);
        if (GameManager.Instance.nodeMap[tilePosition] != null)
            Debug.Log(tilePosition);
    }
    void OnDisable()
    {
        stateMachine.ChangeState(PlayerStateEnums.Idle);
        if (GameManager.Instance.nodeMap.ContainsKey(new Vector2(transform.position.x,transform.position.z)))
        {
            GameManager.Instance.SetWalkable(new Vector2(transform.position.x,transform.position.z), true);
        }
    }

    public void ChangeAnimation(string newAnimation)
    {
        if(curAnimation == newAnimation)    return;

        playerAnimator.Play(newAnimation);

        curAnimation = newAnimation;
    }

    private void Update()
    {
        if (null != stateMachine.curState)
        {
            stateMachine.curState.Execute();
        }
    }

    public override void Hit(float _damage, float _ignore)
    {
        float m_ftDamage = _damage - (entityInfo.defPower - _ignore);
        if (entityInfo.hpCur <= m_ftDamage)
        {
            entityInfo.hpCur = 0f;
            stateMachine.ChangeState(PlayerStateEnums.Dead);
            return;
        }

        entityInfo.hpCur -= m_ftDamage;
        NotifyObservers();
    }
}
