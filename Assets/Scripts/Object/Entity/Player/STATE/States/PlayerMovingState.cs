using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : IPlayerState
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
        player.soul.Moving();
    }

    public void OnStateEnter()
    {
        player.ChangeAnimation(PlayerStateEnums.Moving.ToString());
    }
    public void OnStateExit()
    {
    }
}
