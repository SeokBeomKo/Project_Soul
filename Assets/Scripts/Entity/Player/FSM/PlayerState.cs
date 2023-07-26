using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerState
{
    public Player player {get; set;}
    public PlayerStateMachine stateMachine {get; set;}
    public void Init(PlayerStateMachine stateMachine);
    public void Excute();

    public void OnStateEnter();
    public void OnStateExit();
}
