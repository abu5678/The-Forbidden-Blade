using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public Stat maxHP;
    public Stat damage;
    public bool isInvincible { get; private set; }
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

        targetStats.GetComponent<Entity>().setupKnockbackDirection(transform);
        targetStats.takeDamage(damage.getValue());
    }
    public virtual void takeDamage(int damageTaken)
    {

        if (isInvincible)
            return;

        currentHP -= damageTaken;

        if (currentHP <= 0) 
        {
            Die();
        }
    }

    public virtual void Die()
    {
    }

    public void makeInvincible(bool invincible)
    {
        isInvincible = invincible;
    }
}
