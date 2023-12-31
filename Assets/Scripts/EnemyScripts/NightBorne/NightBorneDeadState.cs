using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class NightBorneDeadState : EnemyState
{
    private NightBorne enemy;
    private float deadTimer;
    private float deathTime = 2;
    public NightBorneDeadState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NightBorne enemy) : base(enemyBase, stateMachine, animBoolName)
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
