using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float Damage = 1;
    public float range = 10;
    public float accuracy = 0.7f;

    public Team Team = Team.BlueTeam;
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, startingPosition) <= range)
        {
            transform.Translate(new Vector3(0, 1) * Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //TODO: React to target
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TankStats>() != null)
        {
            if (collision.gameObject.GetComponent<TankStats>().Team != this.Team)
            {
                collision.SendMessage("TakeDamage", this.Damage);
            }
        }

        if (collision.gameObject.GetComponent<EnemyBase>() != null && this.Team == Team.BlueTeam)
        {
            collision.SendMessage("Damage", Damage);
        }

        Destroy(gameObject);
    }
}
