using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : EnemyState
{
    private EnemySkeleton enemy;
    public SkeletonIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,EnemySkeleton enemy) : base(enemy, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        //the skeleton will stay idle for 1 second
        stateTimer = 1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        //when the 1 second is over the skeleton will start moving
        if (stateTimer < 0 )
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
