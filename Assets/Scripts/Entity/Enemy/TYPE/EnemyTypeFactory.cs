using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeFactory : MonoBehaviour
{
    [SerializeField]    public Enemy            enemy;
    [SerializeField]    public EnemyType        type;
    [SerializeField]    public EnemyTypeEnums   types;

    private void Awake() 
    {
        type.enemy = enemy;
    }
}
