using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField]    public PlayerStateMachine   stateMachine;
    [SerializeField]    public PlayerSoulFactory    soulFactory;
    [SerializeField]    public PlayerSoul           soul;

    [SerializeField]    public Animator             playerAnimator;
    
    // TODO : 삭제
    public bool isMoving;             // 이동 중인지 여부

    public Tile[,] tiles;             // 타일 맵을 저장하는 2차원 배열

    private void Awake()
    {
        targetPosition = transform.parent.position;
        isMoving = false;
    }

    private void Start() 
    {
        ChangeSoul(PlayerSoulType.NONE);
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
            stateMachine.curState.Excute();
        }
    }

    public override IEnumerator Damaged()
    {
        yield return WaitForSecondsPool.GetWaitForSeconds(0.1f);
    }
}
