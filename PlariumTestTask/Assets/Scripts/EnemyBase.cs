using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int health = 10;

    public void Damage(int damage)
    {
        health -= damage;
        Debug.Log($"Base get {damage} damage. Remain {health} health");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
