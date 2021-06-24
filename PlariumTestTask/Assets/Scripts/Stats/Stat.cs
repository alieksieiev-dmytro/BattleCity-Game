using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat<T>
{
    [SerializeField]
    private T baseValue;

    private List<T> modifiers = new List<T>();

    public T GetValue()
    {
        return baseValue;
    }

    public void AddModifier(T modifier)
    {
        if (modifier != null)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(T modifier)
    {
        if (modifier != null)
        {
            modifiers.Remove(modifier);
        }
    }
}
