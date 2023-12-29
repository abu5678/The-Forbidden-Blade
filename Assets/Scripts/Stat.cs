using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private int baseValue;

    public List<int> modifiers;


    public int getValue() 
    {
        int finalValue = baseValue;

        //applies the modifier to every base value
        foreach(int modifier in modifiers)
            finalValue += modifier;

        return finalValue; 
    }

    //add a modifier to increase or decrease damage
    public void addModifier(int modifier)
    {
        modifiers.Add(modifier);
    }
    //remove a modifier
    public void removeModifier(int modifier)
    {
        modifiers.RemoveAt(modifier);
    }

    public int getBaseValue() { return baseValue; }

    public void setBaseValue(int value) { baseValue = baseValue + value; }
}
