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
    }

    private void Fire()
    {
        Transform rotation = GetComponentInChildren<Transform>();


        bulletPrefab.GetComponent<Bullet>().Team = stats.Team;
        bulletPrefab.GetComponent<Bullet>().Damage = stats.damage.GetValue();
        bulletPrefab.GetComponent<Bullet>().range = stats.attackRange.GetValue();
        bulletPrefab.GetComponent<Bullet>().accuracy = stats.accuracy.GetValue();

        _bullet = Instantiate(bulletPrefab) as GameObject;
        _bullet.transform.position =
            transform.TransformPoint(0.15f, 1f, 1.5f);
        _bullet.transform.rotation = transform.rotation;

        _bullet = Instantiate(bulletPrefab) as GameObject;
        _bullet.transform.position =
            transform.TransformPoint(-0.15f, 1f, 1.5f);
        _bullet.transform.rotation = rotation.rotation;
    }

    IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(1f);
        _canShoot = true;
    }
}
