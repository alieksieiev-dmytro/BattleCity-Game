using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New item";
    public Sprite sprite = null;
    public bool isDefaultItem = false;
    public TankModules module;


}
