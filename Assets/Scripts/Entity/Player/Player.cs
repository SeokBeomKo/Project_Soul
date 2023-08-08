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
    }

    public override IEnumerator Damaged()
    {
        yield return WaitForSecondsPool.GetWaitForSeconds(0.1f);
    }
}
