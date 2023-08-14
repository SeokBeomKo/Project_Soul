using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : IPlayerState
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
        player.soul.Attack();
    }

    public void OnStateEnter()
    {
        player.ChangeAnimation(PlayerStateEnums.Attack.ToString());
    }
    public void OnStateExit()
    {
    }
}
