using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public Stat strength;
    public Stat maxHP;
    public Stat damage;
    [SerializeField] public int currentHP;



    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHP = maxHP.getValue();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void doDamage(EntityStats targetStats)
    {
        int totalDamage = damage.getValue() + strength.getValue();
        targetStats.takeDamage(totalDamage);
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
