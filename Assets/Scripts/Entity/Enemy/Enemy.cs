using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField]    public EnemyStateMachine   stateMachine;

    [SerializeField]    public Animator             enemyAnimator;
    [SerializeField]    public string               curAnimation;

    private void Awake()
    {
        targetPosition = transform.parent.position;
    }

    private void Start() 
    {
    }

    public void ChangeAnimation(string newAnimation)
    {
        if(curAnimation == newAnimation)    return;

        enemyAnimator.Play(newAnimation);

        curAnimation = newAnimation;
    }

    private void Update()
    {
        if (null != stateMachine.curState)
        {
            stateMachine.curState.Execute();
        }
    }

    public override IEnumerator Damaged()
    {
        yield return WaitForSecondsPool.GetWaitForSeconds(0.1f);
    }
}
