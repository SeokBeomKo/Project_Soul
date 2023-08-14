using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemySystem;

[CreateAssetMenu(fileName = "EnemyData", menuName ="Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    public EnemyTypeEnums Type;
    public EntityInfo enemyInfo;

    public MeleeInfo meleeInfo;
    public RangeInfo rangeInfo;
    public TurretInfo turretInfo;

    public EliteInfo eliteInfo;
    public BossInfo bossInfo;
}
