using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();

    private void animationTrigger()
    {
        player.AnimationTrigger();
    }

    private void AttackTrigger()
    {
        //stores all the objects that collide 
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        //check each object hit if they are an enemy, if they are cause the enemy to take damage
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                //enemy gets knocked back and flash fx plays
                hit.GetComponent<Enemy>().damageEffect();
                //causes the enemy to take damage according to the players damage
                hit.GetComponent<EntityStats>().takeDamage(player.stats.damage);
            }
        }
    }
}
