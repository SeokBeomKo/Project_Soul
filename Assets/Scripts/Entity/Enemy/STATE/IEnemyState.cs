using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인터페이스 내의 기본 속성은 public
public interface IEnemyState
{
    Enemy enemy {get; set;}
    EnemyStateMachine stateMachine {get; set;}
    void Init(EnemyStateMachine stateMachine);
    void Execute();

    void OnStateEnter();
    void OnStateExit();
}
