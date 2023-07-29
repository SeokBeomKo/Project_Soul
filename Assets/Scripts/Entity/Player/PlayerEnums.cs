using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerStateType
    {
        Idle,           // 플레이어 대기 상태
        Moving,         // 플레이어 이동 중인 상태
        Melee,          // 플레이어 기본 공격 중인 상태
        Skill,          // 플레이어 스킬 사용 중인 상태
        Dead            // 플레이어 사망 상태
    }

    public enum PlayerSoulType
    {
        NONE,

        SWORD,

        BLADE,
        SPEAR,
        BOW,

        DUAL,
        GREATESWORD,
        HALBERD,
        FIST,
        GUN,
        KATANA
    }
