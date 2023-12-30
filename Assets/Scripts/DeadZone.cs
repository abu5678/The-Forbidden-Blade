using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//makes it so that when the player or anything falls off the map they will die
public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EntityStats>() != null)
        {
            collision.GetComponent<EntityStats>().Die();
        }
        else 
            Destroy(collision.gameObject);
    }
}
