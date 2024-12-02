using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // You can add any additional death effects here, like a sound or animation

        Debug.Log("Zombie died!");

        // For object pooling, we would disable the zombie instead of destroying it
        gameObject.SetActive(false);
    }
}
