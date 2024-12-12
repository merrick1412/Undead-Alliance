using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public int attackDamage = 10;        // Damage dealt by the zombie
    public float attackRate = 1f;        // Time in seconds between attacks
    private float nextAttackTime = 0f;   // Timer to control attack rate

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackRate;  // Set the next attack time

            // Assuming the player has a "PlayerHealth" component that handles taking damage
            PlayerHealthController playerHealth = other.GetComponent<PlayerHealthController>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }
}
