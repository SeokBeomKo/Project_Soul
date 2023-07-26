using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerSoul
{
    public Player player {get; set;}

    void Selecting();
    void PickingAttack();
    void Attacking();
    void PickingMove();
    void Idle();
    void Preparing();
    void Moving();
    void Dead();
}

abstract public class PlayerSoul : IPlayerSoul
{
    public Player player {get; set;}

    abstract public void Selecting();
    abstract public void PickingAttack();
    abstract public void Attacking();
    abstract public void PickingMove();

    public void Idle()
    {

    }

    public void Preparing()
    {

    }

    public void Moving()
    {

    }

    public void Dead()
    {

    }
}