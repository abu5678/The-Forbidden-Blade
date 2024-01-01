using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2MagicAttackShadowLordState : EnemyState
{
    private ShadowLord enemy;
    public Phase2MagicAttackShadowLordState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,ShadowLord enemy) : base(enemyBase, stateMachine, animBoolName)
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
    }
}
