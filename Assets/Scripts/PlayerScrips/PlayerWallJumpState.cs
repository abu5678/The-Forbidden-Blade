using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StateTimer = 0.4f;
        //makes the player jump off the wall in the opposite direction
        player.setVelocity(5 * -player.facingDir, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        //if they player has finished jumping they will enter the air state
        if (StateTimer < 0)
            stateMachine.ChangeState(player.airState);
        //if the player reaches the ground they will return back to idle state
        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);

    }
}
