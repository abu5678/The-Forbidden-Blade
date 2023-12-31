using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLordChangePhaseState : EnemyState
{
    private ShadowLord enemy;
    private EnemyStats stats;
    public ShadowLordChangePhaseState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,ShadowLord enemy) : base(enemyBase, stateMachine, animBoolName)
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
        stats = enemy.GetComponent<EnemyStats>();
        enemy.stats.makeInvincible(true);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.stats.makeInvincible(false);
    }

    public override void Update()
    {
        base.Update();
    }
}
