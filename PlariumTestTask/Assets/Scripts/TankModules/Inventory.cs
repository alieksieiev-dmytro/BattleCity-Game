using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }

        instance = this;
    }

    #endregion

    public Item[] modules;
    public Sprite[] sprites;
    private SpriteRenderer[] currentSprites;

    [SerializeField]public TankEquipment player;

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    private void Start()
    {
        currentSprites = new SpriteRenderer[modules.Length];

        foreach (Item module in modules)
        {
            Debug.Log(module.name);
            Debug.Log(module.sprite.name);

            Sprite sprite = module.sprite;

            player.spriteRenderers[(int)module.module].sprite = sprite;
        }
    }

    public void Add(Item item)
    {
        modules[(int)item.module] = item;
        player.spriteRenderers[(int)item.module].sprite = item.sprite;
        //OnItemChangedCallback.Invoke();
    }
}
