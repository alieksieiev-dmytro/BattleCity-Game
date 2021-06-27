using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private float baseValue;
    public StatsTypes type;

    private List<float> modifiers = new List<float>();

    public float GetValue()
    {
        float finalValue = baseValue;

        if (type == StatsTypes.Damage || type == StatsTypes.Health || type == StatsTypes.Range || type == StatsTypes.CountOfBullets)
        {
            modifiers.ForEach(x => finalValue += x);
        }
        else if (type == StatsTypes.Accuracy)
        {
            modifiers.ForEach(x => finalValue *= x);
        }
        else if (type == StatsTypes.Speed)
        {
            modifiers.ForEach(x => finalValue /= x);
        }


        return finalValue;
    }

    public void AddModifier(float modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }
     
    public void RemoveModifier(float modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}
