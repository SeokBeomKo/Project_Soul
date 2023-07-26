using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public Player player;
    public PlayerState curState;
    public Dictionary<PlayerStateType, PlayerState> stateDic = new Dictionary<PlayerStateType, PlayerState>();

    private void Awake()
    {
        
        stateDic.Add(PlayerStateType.IdleState,     new PlayerIdleState()       );  // 상대의 턴을 기다리는 상태
        stateDic.Add(PlayerStateType.ReadyState,    new PlayerReadyState()      );  // 자신의 턴 행동을 기다리는 상태
        stateDic.Add(PlayerStateType.SelectState,   new PlayerSelectState()     );  // 어떤 행동을 할지 기다리는 상태
        stateDic.Add(PlayerStateType.SelMoveState,  new PlayerSelectMoveState() );  // 어디로 이동할지 기다리는 상태
        stateDic.Add(PlayerStateType.MoveState,     new PlayerMoveState()       );  // 이동 상태
        stateDic.Add(PlayerStateType.SelAttackState,new PlayerSelectAttackState()); // 어떤 공격을 할지 기다리는 상태
        stateDic.Add(PlayerStateType.AttackState,   new PlayerAttackState()     );  // 공격 상태
        stateDic.Add(PlayerStateType.HitState,      new PlayerHitState()        );  // 피격 상태
        stateDic.Add(PlayerStateType.DeadState,     new PlayerDeadState()       );  // 사망 상태

        foreach(PlayerState Value in stateDic.Values)
        {
            Value.Init(this);
        }

        ChangeState(PlayerStateType.IdleState);
    }

    public void ChangeState(PlayerStateType newStateType)
    {
        if (null != curState)   curState.OnStateExit();

        if (stateDic.TryGetValue(newStateType, out PlayerState newState))
        {
            curState = newState;
            curState.OnStateEnter();
        }
    }
}
