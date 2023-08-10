using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour
{
    [SerializeField]    public Player    player;

    public void CauseDamage()
    {
        player.soul.OnAttack();
    }
}
