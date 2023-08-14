using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunType : PlayerType
{
    public Transform muzlle;
    public GameObject bullet;

    void Start()
    {
        PoolManager.Instance.AddPool("Bullet",bullet,10);
    }

    private void OnEnable() 
    {
        // player.entityInfo.attRange = 2;
    }

    public override void Attack()
    {
        if (player.attackTarget.entityInfo.hpCur <= 0f)
        {
            player.attackTarget = null;
            player.stateMachine.ChangeState(PlayerStateEnums.Idle);
            return;
        }
        player.transform.parent.LookAt(new Vector3(player.attackTarget.transform.position.x,0,player.attackTarget.transform.position.z));
    }

    public override void OnAttack()
    {
        PoolManager.Instance.SpawnFromPool("Bullet",muzlle.position, player.transform.rotation);

        player.attackTarget.attackTarget = player;
        player.attackTarget.Hit(player.entityInfo.attDamage,player.entityInfo.ignPower);
    }

    public override void Skill()
    {
        
    }
}
