using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLordGroundedState : EnemyState
{
    protected ShadowLord enemy;

    protected Transform player;

    public ShadowLordGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, ShadowLord enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        //if the enemy detects the player infront or right behind them they will enter the battle state
        if (enemy.isPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < 2)
        {
            if (enemy.BossPhase == 1)
                stateMachine.ChangeState(enemy.battleState);
            else
                stateMachine.ChangeState(enemy.phase2BattleState);
        }
    }
}
