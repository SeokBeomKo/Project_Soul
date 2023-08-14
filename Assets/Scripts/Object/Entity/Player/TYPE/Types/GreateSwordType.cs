using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreateSwordType : PlayerType
{
    private void OnEnable() 
    {
        //player.entityInfo.attRange = 1;
    }

    public override void Attack()
    {
        if (player.attackTarget.entityInfo.hpCur <= 0f)
        {
            player.attackTarget = null;
            player.stateMachine.ChangeState(PlayerStateEnums.Idle);

            m_iAttackIndex = 0;
            return;
        }
        player.transform.parent.LookAt(new Vector3(player.attackTarget.transform.position.x,0,player.attackTarget.transform.position.z));
    }
    public int m_iAttackIndex = 0;
    public override void OnAttack()
    {
        //player.playerVFX.attack[m_iAttackIndex].transform.parent.position = transform.position;
        //player.playerVFX.attack[m_iAttackIndex].transform.parent.rotation = transform.rotation;
        player.playerVFX.attack[m_iAttackIndex].Play();
        m_iAttackIndex = (m_iAttackIndex + 1) % player.playerVFX.attack.Count;

        player.attackTarget.GetComponent<Entity>().Hit(player.entityInfo.attDamage,player.entityInfo.ignPower);
        player.attackTarget.GetComponent<Entity>().attackTarget = player;
    }

    public override void Skill()
    {
        
    }
}
