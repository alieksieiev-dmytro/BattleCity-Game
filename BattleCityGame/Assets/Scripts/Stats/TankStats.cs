using System.Collections;
using UnityEngine;

public class TankStats : MonoBehaviour
{
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat speed;
    public Stat maxHealth;
    public Stat accuracy;
    public Stat attackRange;
    public Stat countOfBullets;
    public Team Team;

    private void Awake()
    {
        damage.type = StatsTypes.Damage;
        speed.type = StatsTypes.Speed;
        maxHealth.type = StatsTypes.Health;
        accuracy.type = StatsTypes.Accuracy;
        attackRange.type = StatsTypes.Range;

        currentHealth = (int)maxHealth.GetValue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage > 0 ? damage : 0;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth < 0)
        {
            Die();
        }
    }

    //TODO: Die method implementation
    public virtual void Die()
    {
        Destroy(gameObject);
        Debug.Log(transform.name + " died.");

        int currentAmountOfTanks = GetComponentInParent<EnemyBase>().CurrentAmountOfTanks;

        if (currentAmountOfTanks > 0)
        {
            GetComponentInParent<EnemyBase>().CurrentAmountOfTanks--;
        }
    }

    private IEnumerator TankSpawnDelay()
    {
        yield return new WaitForSeconds(1f);
    }
}
