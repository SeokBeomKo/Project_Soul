using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedState : IPlayerState
{
    public Player player {get; set;}
    public PlayerStateMachine stateMachine {get; set;}
    public void Init(PlayerStateMachine stateMachine)
    {

    }
    public void Excute()
    {
        player.Damaged();
    }

    public void OnStateEnter()
    {

    }
    public void OnStateExit()
    {

    }
}
