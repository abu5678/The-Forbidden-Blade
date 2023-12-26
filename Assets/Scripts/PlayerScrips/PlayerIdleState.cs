using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.setZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        //the player cannot run into a wall 
        if (xInput == player.facingDir && player.isWallDetected())
            return;

        //checks to see if the player is moving left or right and is not performing an action like attacking
        if (xInput != 0 && !player.isBusy)
            stateMachine.ChangeState(player.moveState);
    }
}
