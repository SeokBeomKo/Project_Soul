using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

public class Player : Entity
{
    [SerializeField]    public PlayerStateMachine   stateMachine;
    [SerializeField]    public PlayerTypeFactory    soulFactory;
    [SerializeField]    public PlayerType           soul;

    [SerializeField]    public Animator             playerAnimator;
    [SerializeField]    public string               curAnimation;

    [SerializeField]    public PlayerArea           playerArea;

    public LayerMask clickableLayers;


    private void Awake()
    {
        clickableLayers = ~(1 << LayerMask.NameToLayer("Area"));
        targetPosition = transform.parent.position;
    }

    private void Start() 
    {
        ChangeSoul(PlayerTypeEnums.NONE);
    }

    public void ChangeAnimation(string newAnimation)
    {
        if(curAnimation == newAnimation)    return;

        playerAnimator.Play(newAnimation);

        curAnimation = newAnimation;
    }

    public void ChangeSoul(PlayerTypeEnums soulType)
    {
        // TODO : 무기,의상 모델, 애니메이터, VFX 변경
        soul = soulFactory.GetSoul(soulType);
    }

    private void Update()
    {
        if (null != stateMachine.curState)
        {
            stateMachine.curState.Execute();
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Damaged(10,0));
        }
    }

    public override IEnumerator Damaged(float _damage, float _ignore)
    {
        NotifyObservers();
        if (curHP <= _damage - (defPower - _ignore))
        {
            curHP = 0f;
            stateMachine.ChangeState(PlayerStateEnums.Dead);
            yield break;
        }

        curHP -= 30f;

        yield return WaitForSecondsPool.GetWaitForSeconds(0.1f);
    }
}
