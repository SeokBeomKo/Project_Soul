using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

public class Player : Entity
{
    public float ignore = 0;

    [SerializeField]    public PlayerStateMachine   stateMachine;
    [SerializeField]    public PlayerType           soul;

    [SerializeField]    public Animator             playerAnimator;
    [SerializeField]    public string               curAnimation;

    [SerializeField]    public PlayerArea           playerArea;

    [HideInInspector]   public LayerMask clickableLayers;

    [SerializeField]    public PlayerVFX            playerVFX;


    private void Awake()
    {
        clickableLayers = ~(1 << LayerMask.NameToLayer("Area"));
        targetPosition = transform.parent.position;
        soul.player = this;
    }

    private void Start() 
    {
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
        if (Input.GetMouseButtonDown(0))
        {
            Hit(10,0);
        }
    }

    public override void Hit(float _damage, float _ignore)
    {
        NotifyObservers();
        float m_ftDamage = _damage - (defPower - _ignore);
        if (curHP <= m_ftDamage)
        {
            curHP = 0f;
            stateMachine.ChangeState(PlayerStateEnums.Dead);
            return;
        }

        curHP -= m_ftDamage;
    }
}
