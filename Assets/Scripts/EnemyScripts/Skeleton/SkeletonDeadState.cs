using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDeadState : EnemyState
{
    EnemySkeleton enemy;
    public SkeletonDeadState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void animationFinishTrigger()
    {
        base.animationFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.closeCounterAttackWindow();
        enemy.setZeroVelocity();
        enemy.GetComponent<Collider2D>().enabled = false;
    }
}
