using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillState : IPlayerState
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
        player.soul.Skill();
    }

    public void OnStateEnter()
    {

    }
    public void OnStateExit()
    {

    }
}
