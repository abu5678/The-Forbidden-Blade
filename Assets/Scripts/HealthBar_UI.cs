using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_UI : MonoBehaviour
{
    private Entity entity;
    private RectTransform myTransform;
    private EntityStats stats;
    private Slider slider;

    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
        entity = GetComponentInParent<Entity>();
        slider = GetComponentInChildren<Slider>();
        stats = GetComponentInParent<EntityStats>();

        //when the action/event is called it will flip the healthbar
        entity.onFlipped += FlipUI;
    }
    private void FlipUI()
    {
        //flip the health bar
        myTransform.Rotate(0, 180, 0);
    }
    private void Update()
    {
          updateHealthUI();
    }
    private void updateHealthUI()
    {
        slider.maxValue = stats.maxHP.getValue();
        slider.value = stats.currentHP;
    }

    private void OnDisable()
    {
        entity.onFlipped -= FlipUI;
    }
}
