using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public Player enemy;
    public PlayerState curState;
    public Dictionary<string, PlayerState> stateDic = new Dictionary<string, PlayerState>();

    private void Awake()
    {
        stateDic.Add("AttackState"      , new PlayerAttackState());
        stateDic.Add("IdleState"        , new PlayerIdleState() );
        stateDic.Add("MoveState"        , new PlayerMoveState()   );
        stateDic.Add("ReadyState"       , new PlayerReadyState()  );
        stateDic.Add("SelectAttackState", new PlayerSelectAttackState() );
        stateDic.Add("SelectMoveState"  , new PlayerSelectMoveState() );
        stateDic.Add("SelectState"      , new PlayerSelectState() );

        foreach(PlayerState Value in stateDic.Values)
        {
            Value.Init(this);
        }
    }

    public IEnumerator StartState()
    {
        yield return new WaitForSeconds(0.1f);
        stateDic.TryGetValue("TraceState", out curState);
        curState.OnStateEnter();
    }
    public void ChangeState(PlayerState state)
    {
        curState.OnStateExit();
        curState = state;
        curState.OnStateEnter();
    }
}
