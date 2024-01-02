using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Phase2MagicAttackShadowLordState : EnemyState
{
    private ShadowLord enemy;
    private EnemyStats stats;
    private float magicAttackTime;
    private int exitState = 17;
    public Phase2MagicAttackShadowLordState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,ShadowLord enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void animationFinishTrigger()
    {
        base.animationFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();
        //creates shadow attacks every 4 seconds and makes the enemy invincible while casting
        stats = enemy.GetComponent<EnemyStats>();
        enemy.stats.makeInvincible(true);
        //enemy.createShadowAttack();
        enemy.InvokeRepeating("createShadowAttack", 0, 4);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.stats.makeInvincible(false);
        enemy.Invoke("stopShadowAttack", 0);
    }

    public override void Update()
    {
        base.Update();
        //after a ceratin amount of time the enemy will exit this state
        magicAttackTime += Time.deltaTime;
        if (magicAttackTime > exitState)
            stateMachine.ChangeState(enemy.phase2BattleState);

    }

}
