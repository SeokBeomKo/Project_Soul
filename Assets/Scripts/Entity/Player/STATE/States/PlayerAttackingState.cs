using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : IPlayerState
{
    public Player player {get; set;}
    public PlayerStateMachine stateMachine {get; set;}
    public void Init(PlayerStateMachine stateMachine)
    {

    }
    public void Excute()
    {
        player.soul.Attacking();
    }

    public void OnStateEnter()
    {

    }
    public void OnStateExit()
    {

    }
}
