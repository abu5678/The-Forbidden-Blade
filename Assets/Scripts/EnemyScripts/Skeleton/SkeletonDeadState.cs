using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDeadState : EnemyState
{
    EnemySkeleton enemy;
    private float deadTimer;
    private float deathTime = 2;
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
        deadTimer += Time.deltaTime;
        if (deadTimer >= deathTime)
            enemy.GetComponentInChildren<BoxCollider2D>().enabled = false;
        enemy.GetComponentInChildren<Canvas>().enabled = false;
        enemy.closeCounterAttackWindow();
        enemy.setZeroVelocity();
    }
}
