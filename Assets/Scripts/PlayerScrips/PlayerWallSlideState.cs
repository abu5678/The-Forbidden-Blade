using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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

        //if the player is sliding off a wall and there is no more wall they will enter the air state
        if (!player.isWallDetected())
            stateMachine.ChangeState(player.airState);
           

        //if the player presses space while wall sliding they will perform a wall jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }

        //if the player gets off the wall they will return to idle state
        if (xInput != 0 && player.facingDir != xInput)
            stateMachine.ChangeState(player.idleState);

        //if the user presses the down key they will slide down the wall faster 
        if (yInput < 0)
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        else
            rigidbody2D.velocity = new Vector2 (0,rigidbody2D.velocity.y * 0.7f);

        //if the player has reached the ground they will stop sliding on the wall
        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
