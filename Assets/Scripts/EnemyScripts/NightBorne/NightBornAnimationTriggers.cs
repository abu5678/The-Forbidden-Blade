using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBornAnimationTriggers : MonoBehaviour
{
    private NightBorne enemy => GetComponentInParent<NightBorne>();
    public void animationTrigger()
    {
        enemy.animationFinishTrigger();
    }

    private void AttackTrigger()
    {
        //stores all the objects that collide 
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);

        //check each object hit if they are a player, if they are cause the player to take damage
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                //player gets knocked back and flash fx plays
                hit.GetComponent<Player>().damageEffect();
                //causes the enemy to take damage according to the enemy damage
                hit.GetComponent<EntityStats>().takeDamage(enemy.stats.damage.getValue());
            }

        }
    }

    //open and closes counter attack windows for the enemy
    private void openCounterWindow()
    {
        enemy.OpenCounterAttackWindow();
    }
    private void closeCounterWindow()
    {
        enemy.closeCounterAttackWindow();
    }
}
