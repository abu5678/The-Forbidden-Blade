using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStunnedState : EnemyState
{
    private EnemySkeleton enemy;

    public SkeletonStunnedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        //makes the redcolourblink method keep repeating for 1 second
        enemy.entityFX.InvokeRepeating("RedColourBlink", 0, 1f);
        //how long the enemy should be stunned for
        stateTimer = enemy.stunDuration;
        //causes the stunned enemy to move back
        rigidbody2D.velocity = new Vector2(-enemy.facingDir * enemy.stunDirection.x, enemy.stunDirection.y);
    }

    public override void Exit()
    {
        base.Exit();
        //once the stunned state is over they need to stop changing colours
        enemy.entityFX.Invoke("cancelRedBlink", 0);
    }

    public override void Update()
    {
        base.Update();
        //if the stun duration is over the enemy will return to idle
        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.idleState);
    }
}
