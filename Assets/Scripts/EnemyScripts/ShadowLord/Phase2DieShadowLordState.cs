using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2DieShadowLordState : EnemyState
{
    private ShadowLord enemy;
    private float deadTimer;
    private float deathTime = 2;
    public Phase2DieShadowLordState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, ShadowLord enemy) : base(enemyBase, stateMachine, animBoolName)
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
