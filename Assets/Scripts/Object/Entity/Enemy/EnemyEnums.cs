using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemySystem;

namespace EnemySystem
{
    public enum EnemyStateEnums
    {
        Idle,           // 적 대기 상태
        Moving,         // 적 이동 중인 상태
        Battle,         // 적 전투 돌입 상태
        Attack,         // 적 기본 공격 중인 상태
        Dead,           // 적 사망 상태

        Hit01,          //
        Hit02,          //
    }

    public enum EnemyTypeEnums
    {
        MELEE,
        RANGE,
        TURRET,

        ELITE,

        BOSS,
    }
}
