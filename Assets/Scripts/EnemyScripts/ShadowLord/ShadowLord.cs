using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLord : Enemy
{
    [SerializeField] private Animator animator;
    public int BossPhase = 1;
    public GameObject shadowAttack;
    private Vector3 shadowAttackSpawnLocation;
    public int originalDamage;
    [SerializeField]private float numOfMagicAttacks;
    public int numOfAttacks;

    #region states
    public ShadowLordIdleState idleState { get; private set; }
    public ShadowLordMoveState moveState { get; private set; }
    public ShadowLordBattleState battleState { get; private set; }
    public ShadowLordAttackState attackState { get; private set; }
    public ShadowLordStunnedState stunnedState { get; private set; }
    public ShadowLordDeadState deadState { get; private set; }
    public ShadowLordChangePhaseState changePhaseState { get; private set; }
    public ShadowLordJumpAttackState jumpAttackState { get; private set; }
    public Phase2AttackShadowLordState phase2AttackState { get; private set; }
    public Phase2DieShadowLordState phase2DeadState { get; private set; }
    public Phase2IdleShadowLordState phase2IdleState { get; private set; }
    public Phase2MagicAttackShadowLordState phase2MagicAttackState { get; private set; }
    public Phase2MoveShadowLordState phase2MoveState { get; private set; }
    public Phase2StunnedShadowLordState phase2StunnedState { get; private set; }
    public Phase2BattleShadowLordState phase2BattleState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new ShadowLordIdleState(this, stateMachine, "Idle", this);
        moveState = new ShadowLordMoveState(this, stateMachine, "Move", this);
        battleState = new ShadowLordBattleState(this, stateMachine, "Move", this);
        attackState = new ShadowLordAttackState(this, stateMachine, "Attack", this);
        jumpAttackState = new ShadowLordJumpAttackState(this, stateMachine, "JumpAttack", this);
        stunnedState = new ShadowLordStunnedState(this, stateMachine, "Stunned", this);
        deadState = new ShadowLordDeadState(this, stateMachine, "Die", this);
        changePhaseState = new ShadowLordChangePhaseState(this, stateMachine, "ChangePhase", this);
        phase2AttackState = new Phase2AttackShadowLordState(this, stateMachine, "Phase2Attack", this);
        phase2DeadState = new Phase2DieShadowLordState(this, stateMachine, "Phase2Die", this);
        phase2IdleState = new Phase2IdleShadowLordState(this, stateMachine, "Phase2Idle", this);
        phase2MagicAttackState = new Phase2MagicAttackShadowLordState(this, stateMachine, "Phase2MagicAttack", this);
        phase2MoveState = new Phase2MoveShadowLordState(this, stateMachine, "Phase2Move", this);
        phase2StunnedState = new Phase2StunnedShadowLordState(this, stateMachine, "Phase2Stunned", this);
        phase2BattleState = new Phase2BattleShadowLordState(this, stateMachine, "Phase2Move", this);

    }

    protected override void Start()
    {
        base.Start();
        stateMachine.initialise(idleState);
        originalDamage = this.stats.damage.getBaseValue();
    }

    protected override void Update()
    {
        base.Update();
        if (BossPhase == 1)
            changePhase();
    }

    //if the enemy can be stunned then they will enter the stunned state when this method is called
    public override bool CanBeStunned()
    {
        if (base.CanBeStunned())
        {
            if (BossPhase == 1)
                stateMachine.ChangeState(stunnedState);
            else
                stateMachine.ChangeState(phase2StunnedState);
            return true;
        }
        return false;
    }

    public override void die()
    {
        base.die();
        stateMachine.ChangeState(phase2DeadState);
    }

    public void createShadowAttack()
    {
        for (int i = 0; i < numOfMagicAttacks; i++)
        {
            float spawnAttackX = Random.Range(110.5f, 133.5f);
            shadowAttackSpawnLocation = new Vector3(spawnAttackX, 1.5f, 0);
            Instantiate(shadowAttack, shadowAttackSpawnLocation, Quaternion.identity);
        }
    }
    public void stopShadowAttack()
    {
        CancelInvoke();
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
