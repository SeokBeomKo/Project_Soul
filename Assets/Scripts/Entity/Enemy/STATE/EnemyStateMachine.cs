using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public Enemy enemy;
    public IEnemyState curState;
    public Dictionary<EnemyStateType, IEnemyState> stateDic;

    private void Awake()
    {
        stateDic = new Dictionary<EnemyStateType, IEnemyState>();

        stateDic.Add(EnemyStateType.Idle,         new EnemyIdleState()            );  // 플레이어가 상대 턴 종료를 대기 중인 상태
        stateDic.Add(EnemyStateType.Moving,       new EnemyMovingState()          );  // 플레이어 이동 중인 상태
        stateDic.Add(EnemyStateType.Attack,       new EnemyAttackState()           );  // 플레이어 스킬 사용 상태
        stateDic.Add(EnemyStateType.Dead,         new EnemyDeadState()            );  // 플레이어 사망 상태

        foreach(IEnemyState Value in stateDic.Values)
        {
            Value.Init(this);
        }

        ChangeState(EnemyStateType.Idle);
    }

    public void ChangeState(EnemyStateType newStateType)
    {
        if (null != curState)   curState.OnStateExit();

        if (stateDic.TryGetValue(newStateType, out IEnemyState newState))
        {
            curState = newState;
            curState.OnStateEnter();
        }
    }
}
