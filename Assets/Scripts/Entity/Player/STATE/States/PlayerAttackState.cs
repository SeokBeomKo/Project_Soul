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
        player.transform.parent.LookAt(new Vector3(player.attackTarget.transform.position.x,0,player.attackTarget.transform.position.z));
        player.soul.Attack();
    }

    public void OnStateEnter()
    {
        Debug.Log("Player State : (Enter)Player Attack State");
        player.ChangeAnimation(PlayerStateType.Attack.ToString());
    }
    public void OnStateExit()
    {
        Debug.Log("Player State : (Exit)Player Attack State");
    }
}
