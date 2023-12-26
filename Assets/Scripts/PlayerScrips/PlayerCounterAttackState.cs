using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    public PlayerCounterAttackState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StateTimer = player.counterAttackDurtaion;
        player.animator.SetBool("SuccessfulCounterAttack",false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.setZeroVelocity();
        //stores all the objects that collide 
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        //check each object hit if they are an enemy, if they are check if they can be stunned if they can stun them
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                if(hit.GetComponent<Enemy>().CanBeStunned())
                {
                    StateTimer = 10;
                    player.animator.SetBool("SuccessfulCounterAttack", true);

                }
            }
        }
        //either state timer will be less than 0 and the counter attacked failed
        //or the counter attack is successful making triggerCalled true
        if(StateTimer < 0 || triggerCalled)
        {
            stateMachine.ChangeState(player.idleState); 
        }
    }
}
