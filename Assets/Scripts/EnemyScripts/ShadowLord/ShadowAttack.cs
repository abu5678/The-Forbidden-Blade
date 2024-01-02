using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            EntityStats target = collision.GetComponent<EntityStats>();
            target.takeDamage(15);
            target.GetComponent<Player>().damageEffect();
        }
    }

}
