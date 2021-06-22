using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Awake()
    {
        Instantiate(player, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
