using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    //makes it so that now the skills can be accessed anywhere by using the skill manager
    public static SkillsManager instance;
    public DashSkill dash {  get; private set; }
    public SwordSkillThrow swordThrow { get; private set; }


    private void Awake()
    {
        //makes it so that only one instance can be active at one time
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }
    private void Start()
    {
        dash = GetComponent<DashSkill>();
        swordThrow = GetComponent<SwordSkillThrow>();
    }
}
