using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : TankStats
{
    private void Start()
    {
        ModuleManager.instance.onModuleChanged += OnModuleChanged;

        for (int i = 0; i < ModuleManager.instance.currentModules.Length; i++)
        {
            OnModuleChanged(ModuleManager.instance.currentModules[i], null);
        }
    }

    void OnModuleChanged(Module newItem, Module oldItem)
    {
        if (newItem != null)
        {
            maxHealth.AddModifier(newItem.healthModifier);
            damage.AddModifier(newItem.damageModifier);
            speed.AddModifier(newItem.speedModifier);
            accuracy.AddModifier(newItem.accuracyModifier);
            attackRange.AddModifier(newItem.attackRange);
        }

        if (oldItem != null)
        {
            maxHealth.RemoveModifier(oldItem.healthModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            speed.RemoveModifier(oldItem.speedModifier);
            accuracy.RemoveModifier(oldItem.accuracyModifier);
            attackRange.AddModifier(newItem.attackRange);
        }
    }
}
