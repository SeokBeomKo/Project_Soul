using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerStateType
    {
        Idle,           // 플레이어가 상대 턴 종료를 대기 중인 상태
        Preparing,      // 플레이어 턴 시작 대기 상태
        Selecting,      // 플레이어 선택 후 행동 결정 대기 상태
        PickingMove,    // 이동 후보 위치 선택 대기 상태
        Moving,         // 플레이어 이동 중인 상태
        PickingAttack,  // 공격 대상 선택 대기 상태
        Attacking,      // 플레이어가 공격 중인 상태
        Damaged,        // 플레이어가 데미지를 입은 상태
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
