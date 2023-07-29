using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public Player player;
    public IPlayerState curState;
    public Dictionary<PlayerStateType, IPlayerState> stateDic;

    private void Awake()
    {
        stateDic = new Dictionary<PlayerStateType, IPlayerState>();

        stateDic.Add(PlayerStateType.Idle,         new PlayerIdleState()            );  // 플레이어가 상대 턴 종료를 대기 중인 상태
        stateDic.Add(PlayerStateType.Moving,       new PlayerMovingState()          );  // 플레이어 이동 중인 상태
        stateDic.Add(PlayerStateType.Melee,        new PlayerMeleeState()           );  // 플레이어 공격 중인 상태
        stateDic.Add(PlayerStateType.Skill,        new PlayerSkillState()           );  // 플레이어 스킬 사용 상태
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
