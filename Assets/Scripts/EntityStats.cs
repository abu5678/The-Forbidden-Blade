using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public int maxHP;
    public int damage;
    [SerializeField] private int currentHP;

    // Start is called before the first frame update
    public virtual void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void takeDamage(int damageTaken)
    {
        currentHP -= damageTaken;

        if (currentHP <= 0) 
        {
            Die();
        }
    }

    protected virtual void Die()
    {

    }
}
