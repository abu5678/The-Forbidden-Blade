using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatchSwordState : PlayerState
{
    private Transform sword;
    public PlayerCatchSwordState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        sword = player.sword.transform;
        //makes it so that when the sword is returning the player will face the direction it is returning from
        player.entityFX.ScreenShake(player.entityFX.swordImpactShake);
        if (player.transform.position.x > sword.position.x && player.facingDir == 1)
            player.FlipCharacter();
        else if (player.transform.position.x < sword.position.x && player.facingDir == -1)
            player.FlipCharacter();
        //makes it so that when the sword returns the player will be knocked back a bit
        rigidbody2D.velocity = new Vector2(player.swordReturnImpact * -player.facingDir,rigidbody2D.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        //makes it so that the player cant move and resist knockback when catching
        player.StartCoroutine("BusyFor", 0.1f);

    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
            stateMachine.ChangeState(player.idleState);
    }
}
