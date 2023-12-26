using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : EnemyState
{
    private EnemySkeleton enemy;
    public SkeletonMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,EnemySkeleton enemy) : base(enemy, stateMachine, animBoolName)
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
    }

    public override void Update()
    {
        base.Update();
        //makes the skeleton move forward
        enemy.setVelocity(2 * enemy.facingDir, enemy.rigidbody2D.velocity.y);   

        //checks to see if there is a wall infront or if there is no more platform to walk on since the detections are a bit infront
        //of the skeleton, it will make the skeleton flip and return to idle
        if(enemy.isWallDetected()|| !enemy.IsGroundDetected())
        {
            enemy.FlipCharacter();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
