using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneDeadState : EnemyState
{
    private NightBorne enemy;
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
        enemy.GetComponentInChildren<Canvas>().enabled = false;
        enemy.closeCounterAttackWindow();
        enemy.setZeroVelocity();
    }
}
