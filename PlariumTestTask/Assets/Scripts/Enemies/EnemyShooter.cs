using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyShooter : MonoBehaviour
{
    public AIDestinationSetter setter;

    //public Transform target;
    public TankStats stats;

    [SerializeField] private GameObject bulletPrefab;
    private GameObject _bullet;

    private bool _canShoot = true;

    public AIPath aiPath;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            setter.target = player.GetComponent<Transform>();
        }
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, setter.target.position) < stats.attackRange.GetValue())
        {
            if (_canShoot)
            {
                Fire();
                _canShoot = false;
                StartCoroutine(FireDelay());
            }
            
        }
        /////////////
        if (aiPath.desiredVelocity != Vector3.zero)
        {
            float angle = Mathf.Atan2(aiPath.desiredVelocity.y, aiPath.desiredVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            //targetV = aiPath.destination;

            float angle = Mathf.Atan2(setter.target.position.y - transform.position.y, setter.target.position.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 150f * Time.deltaTime);
        }
    }

    private void Fire()
    {
        Bullet bullet = bulletPrefab.GetComponent<Bullet>();
        bullet.Team = stats.Team;
        bullet.Damage = stats.damage.GetValue();
        bullet.range = stats.attackRange.GetValue();
        bullet.accuracy = stats.accuracy.GetValue();



        _bullet = Instantiate(bulletPrefab) as GameObject;
        _bullet.transform.position =
            transform.TransformPoint(1f, 0.15f, 1.5f);
        _bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -90);

        _bullet = Instantiate(bulletPrefab) as GameObject;
        _bullet.transform.position =
            transform.TransformPoint(1f, -0.15f, 1.5f);
        _bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -90);
        //_bullet.transform.rotation = transform.rotation;
    }

    IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(1f);
        _canShoot = true;
    }
}
