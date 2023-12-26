using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when in battle state the enemy will keep chasing the player until they are within attack range
public class SkeletonBattleState : EnemyState
{
    private Transform player;
    private EnemySkeleton enemy;
    private int moveDir;

    public SkeletonBattleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.isPlayerDetected())
        {
            //if the enemy has detected the player and they are within attack range the enemy will stop
            if (enemy.isPlayerDetected().distance < enemy.attackDistance)
            {
                enemy.ZeroVelocity();
                //return so that he does not try moving anymore
                return;
            }
            
        }

        //if the player is on the right of the enemy the enemy will move to the right
        if (player.position.x > enemy.transform.position.x)
            moveDir = 1;
        //if the player is on the left of the enemy the enemy will move to the left
        else if (player.position.x < enemy.transform.position.x)
            moveDir = -1;

        //makes the enemy move forward
        enemy.setVelocity(enemy.moveSpeed * moveDir,rigidbody2D.velocity.y);
    }
}
