using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
    private Player player;

    protected override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }

    public override void takeDamage(int damageTaken)
    {
        base.takeDamage(damageTaken);
        if (damageTaken > maxHP.getValue() * 0.25f)
            player.entityFX.ScreenShake(player.entityFX.highDamageImpactShake);
    }

    public override void Die()
    {
        base.Die();
        player.stateMachine.ChangeState(player.deadState);
    }
}
