using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string animBoolName;

    protected Rigidbody2D rigidbody2D;

    protected float xInput;
    public PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.player = _player;
        this.animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        player.animator.SetBool(animBoolName, true);
        rigidbody2D = player.rigidbody2D;
    }
    public virtual void Update()
    {
        xInput = Input.GetAxis("Horizontal");
    }
    public virtual void Exit()
    {
        player.animator.SetBool(animBoolName, false);

    }
}
