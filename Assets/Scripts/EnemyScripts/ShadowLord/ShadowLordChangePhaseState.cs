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
        //make him invincible when changing phases
        enemy.closeCounterAttackWindow();
        stats = enemy.GetComponent<EnemyStats>();
        enemy.stats.makeInvincible(true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (triggerCalled)
        {
            enemy.stats.makeInvincible(false);
            stateMachine.ChangeState(enemy.phase2BattleState);
        }
    }
}
