using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEquipment : MonoBehaviour
{
    public Module[] objects;

    public Module GetRandomModule()
    {
        int rand = Random.Range(0, objects.Length);
        return objects[rand];
    }
}
