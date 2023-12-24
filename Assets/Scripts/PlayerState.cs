using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string animBoolName;
    public PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.player = _player;
        this.animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {

    }
    public virtual void Update()
    {

    }
    public virtual void Exit()
    {

    }
}
