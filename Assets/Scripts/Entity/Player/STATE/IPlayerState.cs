using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인터페이스 내의 기본 속성은 public
public interface IPlayerState
{
    Player player {get; set;}
    PlayerStateMachine stateMachine {get; set;}
    void Init(PlayerStateMachine stateMachine);
    void Execute();

    void OnStateEnter();
    void OnStateExit();
}
