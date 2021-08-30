using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public LayerMask whatIsRoom;
    public MapGeneration mapGen;


    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);

        if (roomDetection == null && mapGen.stopGeneration)
        {   
            int rand = Random.Range(0, mapGen.rooms.Length);
            Instantiate(mapGen.rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
