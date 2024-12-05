using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour {
<<<<<<< main
    public Transform player;        // Reference to the player's transform
    private NavMeshAgent navAgent;  // NavMeshAgent for pathfinding

    public float chaseRange = 20f;  // Range in which zombie will start chasing
    public float attackRange = 2f;  // Range in which zombie will attack
    public int attackDamage = 10;   // Damage dealt by the zombie

    private void Start()
=======
    public Transform player;           // Reference to the player
    public float speed = 2f;           // Movement speed
    public float chaseRange = 20f;     // Distance within which zombies chase
    public float attackRange = 2f;     // Distance for attack
    private Rigidbody2D rb;            // Rigidbody2D for 2D movement
    private Vector2 wanderTarget;      // Target for wandering behavior
    private float wanderRadius = 5f;   // Radius for wandering
    private float wanderTimer = 3f;    // Time interval for choosing a new wander target
    private float timer;

    internal void SetDifficulty(int currentRound)
    {
        throw new System.NotImplementedException();
    }

    void Start()
>>>>>>> SkillTree
    {
        navAgent = GetComponent<NavMeshAgent>();
        if (navAgent == null) {
            Debug.LogError("NavMeshAgent component is missing! Disabling ZombieAI.");
            enabled = false; // Disable the script if NavMeshAgent is missing
        }

        if (player == null) {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null) {
                player = playerObject.transform;
            } else {
                Debug.LogError("No GameObject with the 'Player' tag found! Please ensure your player has the correct tag.");
            }
        }
    }

    private void Update() {
        if (navAgent == null || player == null)
            return; // Skip Update if critical components are missing

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange && distanceToPlayer > attackRange) {
            // If the player is within chase range but outside attack range
            ChasePlayer();
        } else if (distanceToPlayer <= attackRange) {
            // If the player is within attack range
            AttackPlayer();
        } else {
            // If the player is outside the chase range
            Idle();
        }
    }

    private void ChasePlayer() {
        navAgent.SetDestination(player.position); // Set player as destination for NavMeshAgent
    }

    private void AttackPlayer() {
        Debug.Log("Zombie is attacking the player!");
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            playerHealth.TakeDamage(attackDamage); // Reduce player's health
        }
    }

    private void Idle() {
        navAgent.SetDestination(transform.position); // Idle, no movement
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
