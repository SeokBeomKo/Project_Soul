using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunType : PlayerType
{
    public Transform muzlle;
    public GameObject bullet;
    public override void Attack()
    {
        if (player.attackTarget.GetComponent<Entity>().curHP <= 0f)
        {
            player.stateMachine.ChangeState(PlayerStateEnums.Idle);
        }
    }

    public override void OnAttack()
    {
        Instantiate(bullet, muzlle.position, player.transform.rotation);
    }

    public override void Skill()
    {
        
    }
}
