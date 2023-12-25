using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //makes the player jump up
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, player.jumpForce);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        //checks if the player is falling down if they are then to change to the air state
        if(rigidbody2D.velocity.y < 0)
        {
            stateMachine.ChangeState(player.airState);
        }
    }
}
