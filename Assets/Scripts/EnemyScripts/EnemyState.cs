using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;

    protected bool triggerCalled;
    private string animBoolName;
    protected float stateTimer;

    protected Rigidbody2D rigidbody2D;

    public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemyBase = enemyBase;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        triggerCalled = false;
        //makes the boolean linked to the animation we want to play  true so the animation will start
        enemyBase.animator.SetBool(animBoolName, true);
        rigidbody2D = enemyBase.rigidbody2D;

    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
    public virtual void Exit() 
    {
        //makes the boolean linked to the animation false so that the animation stops playing
        enemyBase.animator.SetBool(animBoolName, false);

    }

    //used to make an animation stop
    public virtual void animationFinishTrigger()
    {
        triggerCalled = true;
    }
}
