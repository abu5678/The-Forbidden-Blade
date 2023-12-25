using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter;
    private float lastTimeAttacked;
    private float comboWindow = 2;
    public PlayerPrimaryAttackState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //checks if the player has reached the end of the combo or have not attacked for a long while
        //if so the combo counter resets
        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            comboCounter = 0;
        player.animator.SetInteger("ComboCounter", comboCounter);

        //lets the player switch directions when attacking
        float attackDir = player.facingDir;
        if (xInput !=0)
            attackDir = xInput;

        //when the player attacks there is a little step they can do
        StateTimer = 0.1f;
        //makes it so that the player will move forward different amounts depending on what part of the combo they are on
        player.setVelocity(player.attackMovement[comboCounter].x * attackDir, rigidbody2D.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        //every time 1 attack is played the combo counter increase and the time attacked between combos is reset
        comboCounter++;
        lastTimeAttacked = Time.time;
        //makes it so that if the player is trying to do a continuous combo they cannot move while doing it
        //as the player will be busy performing the attack
        player.StartCoroutine("BusyFor", 0.1f);
    }

    public override void Update()
    {
        base.Update();
        //makes it so that the player cannot move while attacking
        if (StateTimer < 0)
            player.ZeroVelocity();
        //once the animation has finished triggerCalled will be true and reset the player back to idle
        if (triggerCalled)
            stateMachine.ChangeState(player.idleState);

    }
}
