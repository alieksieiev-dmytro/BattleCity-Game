using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : TankStats
{
    private void Start()
    {
        //Inventory.instance.OnItemChangedCallback += OnItemChanged;
    }

    void OnItemChanged(Module newItem, Module oldItem)
    {
        if (newItem != null)
        {
            health.AddModifier(newItem.healthModifier);
            damage.AddModifier(newItem.damageModifier);
            speed.AddModifier(newItem.speedModifier);
            accuracy.AddModifier(newItem.accuracyModifier);
        }

        if (oldItem != null)
        {
            health.RemoveModifier(oldItem.healthModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            speed.RemoveModifier(oldItem.speedModifier);
            accuracy.RemoveModifier(oldItem.accuracyModifier);
        }
    }
}
