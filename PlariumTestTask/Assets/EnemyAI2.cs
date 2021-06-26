using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    private TankStats stats;

    private Transform target;

    private void Start()
    {
        stats = GetComponent<TankStats>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stats.attackRange.GetValue())
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, stats.speed.GetValue() * Time.deltaTime);
            transform.LookAt(target.position);
        }
        else if (Vector2.Distance(transform.position, target.position) < stats.attackRange.GetValue() && Vector2.Distance(transform.position, target.position) > stats.attackRange.GetValue() - 1f)
        {
            return;
        }
        else if (Vector2.Distance(transform.position, target.position) < stats.attackRange.GetValue() - 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -stats.speed.GetValue() * Time.deltaTime);
            transform.Rotate(new Vector3(0f, 0f, -180f));
        }
    }
}
