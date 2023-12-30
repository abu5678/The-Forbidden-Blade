using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneBattleState : EnemyState
{
    private Transform player;
    private NightBorne enemy;
    private int moveDir;

    public NightBorneBattleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NightBorne enemy) : base(enemyBase, stateMachine, animBoolName)
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

        if (enemy.isPlayerDetected())
        {
            //used to keep track of how long the enemy has been in the battle state for
            stateTimer = enemy.battleTime;
            //if the enemy has detected the player and they are within attack range the enemy will stop
            if (enemy.isPlayerDetected().distance < enemy.attackDistance)
            {
                //if the enemy attack is not on cooldown it will attack
                if (canAttack())
                    stateMachine.ChangeState(enemy.attackState);
            }

        }
        else
        {
            //if the enemy has been in the battle state for too long and does not detect a player anymore or the player
            //is far away from the enemy the enemy will go back to the idle state
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 10)
                stateMachine.ChangeState(enemy.idleState);
        }

        //if the player is on the right of the enemy the enemy will move to the right
        if (player.position.x > enemy.transform.position.x)
            moveDir = 1;
        //if the player is on the left of the enemy the enemy will move to the left
        else if (player.position.x < enemy.transform.position.x)
            moveDir = -1;

        //makes the enemy move forward
        enemy.setVelocity(enemy.moveSpeed * moveDir, rigidbody2D.velocity.y);
    }

    private bool canAttack()
    {
        //checks to see if enough time has passed since the last time the enemy attacked plus the attack cooldown
        if (Time.time >= enemy.lastTimeAttacked + enemy.attackCooldwon)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }
}
