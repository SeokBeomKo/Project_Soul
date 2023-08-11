using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreateSwordType : PlayerType
{
    public override void Attack()
    {
        if (player.attackTarget.GetComponent<Entity>().curHP <= 0f)
        {
            player.attackTarget = null;
            player.stateMachine.ChangeState(PlayerStateEnums.Idle);
        }
    }
    int m_iAttackIndex = 0;
    public override void OnAttack()
    {
        player.playerVFX.attack[m_iAttackIndex].transform.parent.position = transform.position;
        player.playerVFX.attack[m_iAttackIndex].transform.parent.rotation = transform.rotation;
        player.playerVFX.attack[m_iAttackIndex].Play();
        m_iAttackIndex = (m_iAttackIndex + 1) % player.playerVFX.attack.Count;

        player.attackTarget.GetComponent<Entity>().Hit(player.attDamage,player.ignore);
    }

    public override void Skill()
    {
        
    }
}
