using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLord : Enemy
{
    #region states
    [SerializeField] private Animator animator;
    protected int BossPhase = 1;
    public ShadowLordIdleState idleState { get; private set; }
    public ShadowLordMoveState moveState { get; private set; }
    public ShadowLordBattleState battleState { get; private set; }
    public ShadowLordAttackState attackState { get; private set; }
    public ShadowLordStunnedState stunnedState { get; private set; }
    public ShadowLordDeadState deadState { get; private set; }
    public ShadowLordChangePhaseState changePhaseState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new ShadowLordIdleState(this, stateMachine, "Idle", this);
        moveState = new ShadowLordMoveState(this, stateMachine, "Move", this);
        battleState = new ShadowLordBattleState(this, stateMachine, "Move", this);
        attackState = new ShadowLordAttackState(this, stateMachine, "Attack", this);
        stunnedState = new ShadowLordStunnedState(this, stateMachine, "Stunned", this);
        deadState = new ShadowLordDeadState(this, stateMachine, "Die", this);
        changePhaseState = new ShadowLordChangePhaseState(this, stateMachine, "ChangePhase", this);

    }

    protected override void Start()
    {
        base.Start();
        stateMachine.initialise(idleState);
    }

    protected override void Update()
    {
        base.Update();
        changePhase();
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
    private void CheckJumpAttack()
    {
        if (animator.GetBool("JumpAttack"))
            this.stats.damage.setBaseValue(this.stats.damage.getBaseValue() * 2);
    }
    public override void die()
    {
        base.die();
        stateMachine.ChangeState(deadState);
    }

    private void changePhase()
    {
        if (this.stats.currentHP <= this.stats.maxHP.getValue()/2)
        {
            stateMachine.ChangeState(changePhaseState);
            BossPhase++;

        }
    }
}
