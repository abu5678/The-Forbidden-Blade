using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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
        //the player will start aiming the sword by holding right click, only if there is not one currently active
        if (Input.GetKeyDown(KeyCode.Mouse1) && !player.sword)
            stateMachine.ChangeState(player.aimSwordState);
        //the player can counter attack by pressing Q
        if (Input.GetKeyDown(KeyCode.Q))
            stateMachine.ChangeState(player.counterAttackState);
        //while the player is on the ground they can attack by pressing left click
        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(player.primaryAttackState);
        //checks if the player is on the ground
        if (!player.IsGroundDetected())
            stateMachine.ChangeState(player.airState);
        //if the user presses space the player will jump only if they are on the ground
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected())
            stateMachine.ChangeState(player.jumpState);
    }

}
