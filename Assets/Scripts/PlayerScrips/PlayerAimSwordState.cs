using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimSwordState : PlayerState
{
    public PlayerAimSwordState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.Skills.swordThrow.dotsActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        //makes it so that the player cant move when throwing
        player.StartCoroutine("BusyFor", 0.2f);
    }

    public override void Update()
    {
        player.setZeroVelocity();
        base.Update();
        //if the user lets go of right click they will no longer aim the sword
        if (Input.GetKeyUp(KeyCode.Mouse1))
            stateMachine.ChangeState(player.idleState);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //makes the character flip depending on where the mouse is on the screen
        //if the mouse is on the right of the player they will face the right if the mouse is on the left they face the left
        if (player.transform.position.x > mousePosition.x && player.facingDir == 1)
            player.FlipCharacter();
        else if (player.transform.position.x < mousePosition.x && player.facingDir == -1)
            player.FlipCharacter();
    }
}
