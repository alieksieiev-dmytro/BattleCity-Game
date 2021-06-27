using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : TankStats
{
    public GameObject Tank;

    public int TanksLeft = 30;
    public int CurrentAmountOfTanks = 0;
    public bool isLeft = true;

    private Vector3 leftPosition;
    private Vector3 rightPosition;

    private void Start()
    {
        leftPosition = transform.TransformPoint(-1f, 0f, 0f);
        rightPosition = transform.TransformPoint(1f, 0f, 0f);
    }

    private void Update()
    {
        if (TanksLeft > 0 && CurrentAmountOfTanks < 2)
        {
            if (isLeft)
            {
                Instantiate(Tank, leftPosition, Quaternion.identity, this.gameObject.transform);
                isLeft = false;
            }
            else
            {
                Instantiate(Tank, rightPosition, Quaternion.identity, this.gameObject.transform);
                isLeft = true;
            }

            CurrentAmountOfTanks++;
            TanksLeft--;
        }
        else if (TanksLeft == 0)
        {
            SessionManager.instance.GameWon();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
        SessionManager.instance.GameWon();
    }
}
