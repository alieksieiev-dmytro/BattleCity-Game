using UnityEngine;

public class TankStats : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat<int> damage;
    public Stat<float> speed;
    public Stat<int> health;
    public Stat<float> accuracy;

    private void Awake()
    {
        currentHealth = MaxHealth;
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

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //TODO: Die method implementation
    public virtual void Die()
    {
        Debug.Log(transform.name + " died.");
    }
}
