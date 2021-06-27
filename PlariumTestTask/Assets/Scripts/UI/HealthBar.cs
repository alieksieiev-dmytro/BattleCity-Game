using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public PlayerStats stats;

    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        SetMaxHealth();
    }

    public void SetMaxHealth()
    {
        slider.maxValue = stats.maxHealth.GetValue();
        slider.value = stats.maxHealth.GetValue();
    }

    private void Update()
    {
        slider.value = stats.currentHealth;
    }
}
