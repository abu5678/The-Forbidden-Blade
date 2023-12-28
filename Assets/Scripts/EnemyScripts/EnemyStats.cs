using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : EntityStats
{
    private EnemySkeleton enemy;
    public override void Start()
    {
        base.Start();
        enemy = GetComponent<EnemySkeleton>();
    }

    public override void takeDamage(int damageTaken)
    {
        base.takeDamage(damageTaken);
    }

    protected override void Die()
    {
        base.Die();
        enemy.stateMachine.ChangeState(enemy.deadState);
    }
}
