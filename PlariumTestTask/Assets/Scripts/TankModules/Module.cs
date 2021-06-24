using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Module", menuName = "Inventory/Module")]
public class Module : Item
{
    public SpriteRenderer sprite;

    public TankModules module;

    public int healthModifier;
    public float speedModifier;
    public int damageModifier;
    public float accuracyModifier;
    public float attackRange;

    public override void Use()
    {
        base.Use();
        ModuleManager.instance.Equip(this);
    }
}
