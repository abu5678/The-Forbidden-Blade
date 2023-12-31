using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{

    public PlayerDashState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //makes it so that the timer is as long as the dash duration
        StateTimer = player.dashDuration;
        player.stats.makeInvincible(true);
    }

    public override void Exit()
    {
        base.Exit();
        //makes it so that once we exit the dash state the player is not dashing forward
        player.setVelocity(0,rigidbody2D.velocity.y);
        player.stats.makeInvincible(false);
    }

    public override void Update()
    {
        base.Update();

        //if the player dashes onto a wall they will wall slide
        if (!player.IsGroundDetected() && player.isWallDetected())
            stateMachine.ChangeState(player.wallSlideState);

        //makes the player dash forward
        player.setVelocity(player.dashSpeed * player.dashDir,0);
        //checking if dash is finished
        if (StateTimer < 0)
            stateMachine.ChangeState(player.idleState);

        //creates the after image fx when dashing
        player.entityFX.CreateAfterImage();
    }
}
