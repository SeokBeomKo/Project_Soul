using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    public Player player {get; set;}
    public PlayerStateMachine stateMachine {get; set;}
    public void Init(PlayerStateMachine stateMachine)
    {

    }
    public void Excute()
    {
        stateMachine.ChangeState(PlayerStateType.Preparing);
    }

    public void OnStateEnter()
    {
        Debug.Log("Player State : (Enter)Player Idle State");
    }
    public void OnStateExit()
    {
        Debug.Log("Player State : (Exit)Player Idle State");
    }
}
