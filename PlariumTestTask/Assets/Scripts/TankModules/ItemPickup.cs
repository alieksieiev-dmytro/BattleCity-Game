using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Module item;

    public override void Use()
    {
        base.Use();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);

        ModuleManager.instance.Equip(item);

        Destroy(gameObject);
    }
}
