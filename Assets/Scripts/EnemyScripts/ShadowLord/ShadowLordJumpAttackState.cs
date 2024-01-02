using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLordJumpAttackState : EnemyState
{
    private ShadowLord enemy;
    private EnemyStats stats;
    public ShadowLordJumpAttackState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, ShadowLord enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        stats = enemy.GetComponent<EnemyStats>();
        enemy.stats.makeInvincible(true);
        //doubles damage for jump attack
        enemy.stats.damage.setBaseValue(enemy.originalDamage);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.stats.makeInvincible(false);
        //sets the last time attacked to the current time once the enemy exits the attack state
        enemy.lastTimeAttacked = Time.time;
        enemy.stats.damage.setBaseValue(-enemy.originalDamage);
    }

    public override void Update()
    {
        base.Update();
        //makes the enemy stop moving   
        enemy.setZeroVelocity();

        //once tha animation is over triggered called will be true and the enemy will enter the battle state again
        if (triggerCalled)
            stateMachine.ChangeState(enemy.battleState);
    }
}
