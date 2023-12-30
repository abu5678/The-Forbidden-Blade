using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//used if any events need to happen during animations
public class SkeletonAnimationTriggers : MonoBehaviour
{
    private EnemySkeleton enemy => GetComponentInParent<EnemySkeleton>();

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
                PlayerStats target = hit.GetComponent<PlayerStats>();
                //player gets knocked back and flash fx plays
                enemy.stats.doDamage(target);
                hit.GetComponent<Player>().damageEffect();
                //causes the enemy to take damage according to the enemy damage
            }

        }
    }

    //open and closes counter attack windows for the skeleton
    private void openCounterWindow()
    {
        enemy.OpenCounterAttackWindow();
    }
    private void closeCounterWindow()
    {
        enemy.closeCounterAttackWindow();
    }
}
