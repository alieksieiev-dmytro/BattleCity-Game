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

        SpriteRenderer newSprite = Instantiate<SpriteRenderer>(newModule.sprite);
        newSprite.transform.parent = targetSprite.transform;
        newSprite.transform.position = targetSprite.transform.position;
        Destroy(newSprite.GetComponent<ItemPickup>());

        if (!_isDefaultModule)
        {
            newSprite.transform.rotation = targetSprite.transform.rotation;
            newSprite.transform.Rotate(new Vector3(0, 0, -90), Space.Self);
            Destroy(oldSprite.gameObject);
        }


        currentSprites[moduleType] = newSprite;
    }
}
