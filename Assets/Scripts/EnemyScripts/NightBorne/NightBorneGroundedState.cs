using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneGroundedState : EnemyState
{
    protected NightBorne enemy;

    protected Transform player;

    public NightBorneGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NightBorne enemy) : base(enemyBase, stateMachine, animBoolName)
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
            stateMachine.ChangeState(enemy.battleState);
    }
}
