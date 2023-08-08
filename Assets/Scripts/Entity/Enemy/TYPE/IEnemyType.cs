using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyType
{
    Enemy enemy {get; set;}

    void Idle();
    void Moving();
    void Attack();
    void Skill();
    void Dead();
}

public abstract class EnemyType : IEnemyType
{
    public Enemy enemy {get; set;}

    abstract public void Idle();
    abstract public void Moving();
    abstract public void Attack();
    abstract public void Skill();
    public void Dead()
    {
        
    }
}
