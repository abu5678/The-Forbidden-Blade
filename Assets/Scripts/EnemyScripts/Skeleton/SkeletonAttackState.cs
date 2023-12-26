using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : EnemyState
{
    private EnemySkeleton enemy;
    public SkeletonAttackState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : base(enemyBase, stateMachine, animBoolName)
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

        //sets the last time attacked to the current time once the skeleton exits the attack state
        enemy.lastTimeAttacked = Time.time; 
    }

    public override void Update()
    {
        base.Update();
        //makes the enemy stop moving   
        enemy.setZeroVelocity();

        //once tha animation is over triggered called will be true and the skeleton will enter the battle state again
        if (triggerCalled)
            stateMachine.ChangeState(enemy.battleState);
    }
}


