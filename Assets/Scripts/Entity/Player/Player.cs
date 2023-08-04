using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

public class Player : Entity
{
    [SerializeField]    public PlayerStateMachine   stateMachine;
    [SerializeField]    public PlayerSoulFactory    soulFactory;
    [SerializeField]    public PlayerSoul           soul;

    [SerializeField]    public Animator             playerAnimator;
    [SerializeField]    public string               curAnimation;

    [SerializeField]    public GameObject           game;

    private void Awake()
    {
        targetPosition = transform.parent.position;
    }

    private void Start() 
    {
        ChangeSoul(PlayerSoulType.NONE);
    }

    public void ChangeAnimation(string newAnimation)
    {
        if(curAnimation == newAnimation)    return;

        playerAnimator.Play(newAnimation);

        curAnimation = newAnimation;
    }

    public void ChangeSoul(PlayerSoulType soulType)
    {
        // TODO : 무기,의상 모델 과 애니메이터 변경
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
