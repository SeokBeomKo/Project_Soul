using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public Player player;
    public IPlayerState curState;
    public Dictionary<PlayerStateEnums, IPlayerState> stateDic;

    private void Awake()
    {
        stateDic = new Dictionary<PlayerStateEnums, IPlayerState>
        {
            { PlayerStateEnums.Idle,      new PlayerIdleState()},
            { PlayerStateEnums.Moving,    new PlayerMovingState()},
            { PlayerStateEnums.Attack,    new PlayerAttackState()},
            { PlayerStateEnums.Skill,     new PlayerSkillState()},
            { PlayerStateEnums.Dead,      new PlayerDeadState()}
        };

        foreach(IPlayerState Value in stateDic.Values)
        {
            Value.Init(this);
        }

        ChangeState(PlayerStateEnums.Idle);
    }

    public void ChangeState(PlayerStateEnums newStateType)
    {
        if (null != curState)   curState.OnStateExit();

        if (stateDic.TryGetValue(newStateType, out IPlayerState newState))
        {
            curState = newState;
            curState.OnStateEnter();
        }
    }
}
