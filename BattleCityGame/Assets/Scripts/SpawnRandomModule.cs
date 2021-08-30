using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomModule : MonoBehaviour
{
    public GameObject[] objects;

    public GameObject GetRandomObject()
    {
        int rand = Random.Range(0, objects.Length);
        return objects[rand];
    }
}
