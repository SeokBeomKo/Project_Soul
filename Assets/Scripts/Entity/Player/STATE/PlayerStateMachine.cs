using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public Player player;
    public IPlayerState curState;
    public Dictionary<PlayerStateType, IPlayerState> stateDic = new Dictionary<PlayerStateType, IPlayerState>();

    private void Awake()
    {
        
        stateDic.Add(PlayerStateType.Idle,         new PlayerIdleState()            );  // 플레이어가 상대 턴 종료를 대기 중인 상태
        stateDic.Add(PlayerStateType.Preparing,    new PlayerPreparingState()       );  // 플레이어 턴 시작 대기 상태
        stateDic.Add(PlayerStateType.Selecting,    new PlayerSelectingState()       );  // 플레이어 선택 후 행동 결정 대기 상태
        stateDic.Add(PlayerStateType.PickingMove,  new PlayerPickingMoveState()     );  // 이동 후보 위치 선택 대기 상태
        stateDic.Add(PlayerStateType.Moving,       new PlayerMovingState()          );  // 플레이어 이동 중인 상태
        stateDic.Add(PlayerStateType.PickingAttack,new PlayerPickingAttackState()   );  // 공격 대상 선택 대기 상태
        stateDic.Add(PlayerStateType.Attacking,    new PlayerAttackingState()       );  // 플레이어가 공격 중인 상태
        stateDic.Add(PlayerStateType.Damaged,      new PlayerDamagedState()         );  // 플레이어가 데미지를 입은 상태
        stateDic.Add(PlayerStateType.Dead,         new PlayerDeadState()            );  // 플레이어 사망 상태

        foreach(IPlayerState Value in stateDic.Values)
        {
            Value.Init(this);
        }

        ChangeState(PlayerStateType.Idle);
    }

    public void ChangeState(PlayerStateType newStateType)
    {
        if (null != curState)   curState.OnStateExit();

        if (stateDic.TryGetValue(newStateType, out IPlayerState newState))
        {
            curState = newState;
            curState.OnStateEnter();
        }
    }
}
