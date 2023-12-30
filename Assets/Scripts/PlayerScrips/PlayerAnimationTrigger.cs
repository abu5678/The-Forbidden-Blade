using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    [SerializeField] private GameOverScreen gameOverScreen;

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
                EnemyStats target = hit.GetComponent<EnemyStats>();
                if (target.currentHP > 0)
                {
                    //enemy gets knocked back and flash fx plays
                    player.stats.doDamage(target);
                    hit.GetComponent<Enemy>().damageEffect();
                }

            }
        }
    }

    private void ThrowSword()
    {
        //will create a sword to throw at some point of the sword throw animation
        SkillsManager.instance.swordThrow.createSword();
    }

    private void gameOver()
    {
        gameOverScreen.showScreen();
    }
}
