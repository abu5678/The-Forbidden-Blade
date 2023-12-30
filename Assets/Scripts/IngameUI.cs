using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private PlayerStats playerStats;

    private void Update()
    {
        updateHealthUI();   
    }

    private void updateHealthUI()
    {
        slider.maxValue = playerStats.maxHP.getValue();
        slider.value = playerStats.currentHP;
    }
}
