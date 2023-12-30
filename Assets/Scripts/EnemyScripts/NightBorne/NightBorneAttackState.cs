using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneAttackState : EnemyState
{
    private NightBorne enemy;
    public NightBorneAttackState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NightBorne enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        //sets the last time attacked to the current time once the enemy exits the attack state
        enemy.lastTimeAttacked = Time.time;
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
