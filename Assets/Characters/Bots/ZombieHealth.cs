using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public LootController lc;
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject levelSystem;
    public int zHealthMultiplier;
    private void Start()
    {
        levelSystem = FindObjectOfType<LevelSystem>().gameObject;
        lc = FindObjectOfType<LootController>();
        maxHealth = 100 + (levelSystem.GetComponent<LevelSystem>().GetLevelNumber() * zHealthMultiplier);
        currentHealth = maxHealth;
    }

    public void ZombieTakeDamage(int damage)
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
        lc.LootRoll(gameObject.transform);

        levelSystem.GetComponent<LevelSystem>().AddExperience(10); //levels player
        // For object pooling, we would disable the zombie instead of destroying it
        Destroy(gameObject);
    }
}
