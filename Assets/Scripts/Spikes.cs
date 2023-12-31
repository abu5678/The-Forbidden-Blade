using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EntityStats>() != null)
        {
            EntityStats target = collision.GetComponent<EntityStats>();
            target.takeDamage(10);
            target.GetComponent<Entity>().damageEffect();
        }

    }
}
