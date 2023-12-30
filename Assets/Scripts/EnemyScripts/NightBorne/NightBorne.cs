using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorne : Enemy
{
    #region states
    public NightBorneIdleState idleState { get; private set; }
    public NightBorneMoveState moveState { get; private set; }
    public NightBorneBattleState battleState { get; private set; }
    public NightBorneAttackState attackState { get; private set; }
    public NightBorneStunnedState stunnedState { get; private set; }
    public NightBorneDeadState deadState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new NightBorneIdleState(this, stateMachine, "Idle", this);
        moveState = new NightBorneMoveState(this, stateMachine, "Move", this);
        battleState = new NightBorneBattleState(this, stateMachine, "Move", this);
        attackState = new NightBorneAttackState(this, stateMachine, "Attack", this);
        stunnedState = new NightBorneStunnedState(this, stateMachine, "Stunned", this);
        deadState = new NightBorneDeadState(this, stateMachine, "Die", this);

    }

    protected override void Start()
    {
        base.Start();
        stateMachine.initialise(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    //if the enemy can be stunned then they will enter the stunned state when this method is called
    public override bool CanBeStunned()
    {
        if (base.CanBeStunned())
        {
            stateMachine.ChangeState(stunnedState);
            return true;
        }
        return false;
    }
    public override void die()
    {
        base.die();
        stateMachine.ChangeState(deadState);
    }
}
