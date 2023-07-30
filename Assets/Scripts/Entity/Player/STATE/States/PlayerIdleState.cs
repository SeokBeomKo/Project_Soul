using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 기본 대기 상태
// 조건 1. 플레이어가 이동 가능한 타일을 선택한 경우 -> PlayerMovingState
// 조건 2. 플레이어가 
public class PlayerIdleState : IPlayerState
{
    public Player player {get; set;}
    public PlayerStateMachine stateMachine {get; set;}
    public void Init(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        player = stateMachine.player;
    }

    public void Execute()
    {
        player.soul.Idle();
    }

    public void OnStateEnter()
    {
        Debug.Log("Player State : (Enter)Player Idle State");
        player.ChangeAnimation(PlayerStateType.Idle.ToString());
    }
    public void OnStateExit()
    {
        Debug.Log("Player State : (Exit)Player Idle State");
    }
}
