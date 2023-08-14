using System.Collections;
using System.Collections.Generic;
using EnemySystem;
using UnityEngine;

public class EnemyAnimationEventHandler : MonoBehaviour
{
    [SerializeField]    public Enemy    enemy;

    public void CauseDamage()
    {
        enemy.OnAttack();
    }
}
