using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace EnemySystem
{
    [Serializable] public struct EnemyInfo
    {
        public string name;         // 이름
        public float moveSpeed;     // 이동 속도
        public int maxHP;           // 최대 체력
        public int range;           // 공격 사거리
        public int attack;          // 공격력
        public float attackSpeed;   // 공격 속도
        public int ignore;          // 방어 관통
        public int defence;         // 방어력
        public int exp;             // 경험치
    }

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

