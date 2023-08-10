using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreateSwordType : PlayerType
{
    public override void Attack()
    {

    }
    int m_iAttackIndex = 0;
    public override void OnAttack()
    {
        player.playerVFX.attack[m_iAttackIndex].transform.parent.position = transform.position;
        player.playerVFX.attack[m_iAttackIndex].transform.parent.rotation = transform.rotation;
        player.playerVFX.attack[m_iAttackIndex].Play();
        Debug.Log(m_iAttackIndex);
        Debug.Log(player.playerVFX.attack.Count);
        m_iAttackIndex = (m_iAttackIndex + 1) % player.playerVFX.attack.Count;
    }

    public override void Skill()
    {
        
    }
}
