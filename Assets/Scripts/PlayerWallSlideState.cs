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
