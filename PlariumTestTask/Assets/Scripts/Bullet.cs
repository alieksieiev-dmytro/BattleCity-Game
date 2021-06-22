using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    private void Update()
    {
        transform.Translate(new Vector3(0, 1) * Time.deltaTime * speed);
    }

    //TODO: React to target
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
