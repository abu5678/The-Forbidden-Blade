using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected float cooldownTimer;
    protected Player player;

    protected virtual void Start()
    {
        player = PlayerManager.instance.player;
    }
    protected virtual void Update ()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public virtual bool CanUseSkill()
    {
        if(cooldownTimer <= 0)
        {
            //uses the skill and resets that skills cooldown
            useSkill();
            cooldownTimer = cooldown;
            return true;
        } 
        else
            return false;
            
    }
    public virtual void useSkill()
    {

    }
}
