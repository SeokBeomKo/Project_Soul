using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace EnemySystem
{
    [Serializable] public struct EliteInfo
    {
        public float skillDelay;        // 스킬 대기시간
        public int skillDistance;       // 스킬 유지 거리
        public float skillSpeed;        // 스킬 발동시 이동 속도
    }

    [Serializable] public struct BossInfo
    {   
        public float skillDelay;        // 스킬 대기시간
        public int skillRange;          // 스킬 범위       (실제 데미지유효 거리)
        public int skillAttack;         // 스킬 공격력
    }
}

