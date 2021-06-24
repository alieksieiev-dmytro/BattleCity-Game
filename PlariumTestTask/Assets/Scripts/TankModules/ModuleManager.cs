using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    #region Singleton

    public static ModuleManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Module Manager found");
            return;
        }

        instance = this;
    }

    #endregion

    public SpriteRenderer targetSprite;
    public Module[] currentModules;
    SpriteRenderer[] currentSprites;

    public GameObject[] defaultModules;
    private bool _isDefaultModule;

    public delegate void OnModuleChanged(Module newModule, Module oldModule);
    public OnModuleChanged onModuleChanged;

    private void Start()
    {
        currentModules = new Module[Enum.GetNames(typeof(TankModules)).Length];
        currentSprites = new SpriteRenderer[Enum.GetNames(typeof(TankModules)).Length];

        _isDefaultModule = true;

        for (int i = 0; i < defaultModules.Length; i++)
        {
            Equip(defaultModules[i].GetComponent<RandomEquipment>().GetRandomModule());
        }

        _isDefaultModule = false;
    }

    public void Equip(Module newModule)
    {
        int moduleType = (int)newModule.module;

        Module oldModule = currentModules[moduleType];
        SpriteRenderer oldSprite = currentSprites[moduleType];

        if (onModuleChanged != null)
        {
            onModuleChanged.Invoke(newModule, oldModule);
        }

        currentModules[moduleType] = newModule;

        //SpriteRenderer sprite = Instantiate<SpriteRenderer>(new SpriteRenderer());
        //sprite.sortingOrder = moduleType++;
        //sprite.sprite = currentSprites[moduleType].sprite;
        //sprite.transform.position = targetSprite.transform.position;
        //sprite.transform.parent = targetSprite.transform;

        SpriteRenderer newSprite = Instantiate<SpriteRenderer>(newModule.sprite);
        newSprite.transform.position = targetSprite.transform.position;
        newSprite.transform.parent = targetSprite.transform;
        Destroy(newSprite.GetComponent<ItemPickup>());

        if (!_isDefaultModule)
        {
            Destroy(oldSprite.gameObject);
        }

        currentSprites[moduleType] = newSprite;
    }
}
