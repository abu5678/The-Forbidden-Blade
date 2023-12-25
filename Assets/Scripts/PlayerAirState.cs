using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
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
        //checks to see if the player is hitting a wall
        if (player.isWallDetected())
            stateMachine.ChangeState(player.wallSlideState);
        //check to see if the player has reached the ground
        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
        //makes it so that the player can move left and right in the air
        if (xInput != 0)
            player.setVelocity(xInput * player.moveSpeed * 0.8f, rigidbody2D.velocity.y);
    }
}
