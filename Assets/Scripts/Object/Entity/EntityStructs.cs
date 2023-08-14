using System;

[Serializable]
public struct EntityInfo
{
    public string           name;     // 이름

    public float            moveSpeed;  // 이동 속도

    public float            hpMax;      // 최대 체력
    public float            hpCur;      // 현재 체력

    public int              attRange;   // 공격 사거리
    public float            attSpeed;   // 공격 속도
    public int              attDamage;  // 공격력

    public float            defPower;   // 방어력
    public float            ignPower;   // 관통력
}
