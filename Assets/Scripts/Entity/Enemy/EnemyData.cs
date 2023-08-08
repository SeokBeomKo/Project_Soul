using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    [CreateAssetMenu(fileName = "EnemyData", menuName ="Data/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public EnemyTypeEnums Type;

        public EnemyInfo enemyInfo;
        public MeleeInfo normalInfo;
        public RangeInfo dashInfo;
        public BossInfo bombInfo;
    }
}
