using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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

        //makes the player can move left and right
        player.setVelocity(xInput *  player.moveSpeed,rigidbody2D.velocity.y);

        //if the player is standing still and not moving left or right or is hitting the wall to become idle
        if (xInput == 0 || player.isWallDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
