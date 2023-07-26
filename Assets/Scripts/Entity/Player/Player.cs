using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField]    public PlayerStateMachine stateMachine;
    
    // TODO : 삭제
    public bool isMoving;             // 이동 중인지 여부

    public Tile[,] tiles;             // 타일 맵을 저장하는 2차원 배열

    private void Awake()
    {
        targetPosition = transform.parent.position;
        isMoving = false;
    }

    private void Update()
    {
        if (null != stateMachine.curState)
        {
            stateMachine.curState.Excute();
        }
    }
}
