using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
    private Player player;

    public override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }

    public override void takeDamage(int damageTaken)
    {
        base.takeDamage(damageTaken);
    }

    protected override void Die()
    {
        base.Die();
        player.stateMachine.ChangeState(player.deadState);
    }
}
