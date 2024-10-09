using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public int attackDamage = 10;   // Damage dealt by the zombie
    public float attackRate = 1f;   // How often the zombie attacks (in seconds)
    private float nextAttackTime = 0f;  // Timer to control attack rate

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackRate;  // Set the next time the zombie can attack
            Attack(other);   // Attack the player
        }
    }

    private void Attack(Collider player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();  // Access the player's health script
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);  // Apply damage to the player
            Debug.Log("Zombie attacks the player for " + attackDamage + " damage!");
        }
    }
}
