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
    Module[] currentModules;
    SpriteRenderer[] currentSprites;

    public GameObject[] defaultModules;

    public delegate void OnModuleChanged(Module newModule, Module oldModule);
    public OnModuleChanged onModuleChanged;

    private void Start()
    {
        currentModules = new Module[Enum.GetNames(typeof(TankModules)).Length];
        currentSprites = new SpriteRenderer[Enum.GetNames(typeof(TankModules)).Length];

        for (int i = 0; i < defaultModules.Length; i++)
        {
            Equip(defaultModules[i].GetComponent<RandomEquipment>().GetRandomModule());
        }
    }

    public void Equip(Module newModule)
    {
        int moduleType = (int)newModule.module;

        Module oldModule = currentModules[moduleType];

        if (onModuleChanged != null)
        {
            onModuleChanged.Invoke(newModule, oldModule);
        }

        currentModules[moduleType] = newModule;

        SpriteRenderer newSprite = Instantiate<SpriteRenderer>(newModule.sprite);
        newSprite.transform.position = targetSprite.transform.position;
        newSprite.transform.parent = targetSprite.transform;

        currentSprites[moduleType] = newSprite;
    }
}
