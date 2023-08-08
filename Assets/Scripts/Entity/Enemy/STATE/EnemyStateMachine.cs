using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public Enemy enemy;
    public IEnemyState curState;
    public Dictionary<EnemyStateEnums, IEnemyState> stateDic;

    private void Awake()
    {
        stateDic = new Dictionary<EnemyStateEnums, IEnemyState>
        {
            { EnemyStateEnums.Idle,      new EnemyIdleState()},
            { EnemyStateEnums.Moving,    new EnemyMovingState()},
            { EnemyStateEnums.Attack,    new EnemyAttackState()},
            { EnemyStateEnums.Dead,      new EnemyDeadState()}
        };

        foreach(IEnemyState Value in stateDic.Values)
        {
            Value.Init(this);
        }

        ChangeState(EnemyStateEnums.Idle);
    }

    public void ChangeState(EnemyStateEnums newStateType)
    {
        if (null != curState)   curState.OnStateExit();

        if (stateDic.TryGetValue(newStateType, out IEnemyState newState))
        {
            curState = newState;
            curState.OnStateEnter();
        }
    }
}
