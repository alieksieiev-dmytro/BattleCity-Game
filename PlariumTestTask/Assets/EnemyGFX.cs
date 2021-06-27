using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyGFX : MonoBehaviour
{
    public float rotatingSpeed = 150.0f;

    public AIPath aiPath;
    //public Transform target;

    public Vector3 targetV;

    void Update()
    {
        //if (aiPath.desiredVelocity != Vector3.zero)
        //{
        //    float angle = Mathf.Atan2(aiPath.desiredVelocity.y, aiPath.desiredVelocity.x) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //}
        //else
        //{
        //    targetV = aiPath.destination;

        //    float angle = Mathf.Atan2(targetV.y - transform.position.y, targetV.x - transform.position.x) * Mathf.Rad2Deg;
        //    Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 150f * Time.deltaTime);
        //}
    }
}
