using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneSoul : PlayerSoul
{
    public override void Attack()
    {
        // 공격 불가
        player.stateMachine.ChangeState(PlayerStateType.Idle);
    }

    public override void Skill()
    {
        // 공격 불가
        player.stateMachine.ChangeState(PlayerStateType.Idle);
    }
}
