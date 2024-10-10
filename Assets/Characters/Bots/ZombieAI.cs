using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{

    public GameObject Traget; //tester for cube
    public float speed = 2f;        // Speed at which the zombie moves test for cube
    public Transform player;        // Reference to the player's transform
    private NavMeshAgent navAgent;  // NavMeshAgent for pathfinding

    public float chaseRange = 20f;  // Range in which zombie will start chasing
    public float attackRange = 2f;  // Range in which zombie will attack
    public int attackDamage = 10;   // Damage dealt by the zombie

    private bool isPlayerInRange;   // Boolean to track if player is within chase range

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>(); // Assign NavMeshAgent
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange && distanceToPlayer > attackRange)
        {
            // If the player is within chase range but outside attack range
            ChasePlayer();
        }
        else if (distanceToPlayer <= attackRange)
        {
            // If the player is within attack range
            AttackPlayer();
        }
        else
        {
            // If the player is outside the chase range
            Idle();
        }
    }
    private void ChasePlayer()
    {
        // Assuming 'Traget' is a GameObject, access its transform's position
        Vector3 targetPosition = new Vector3(Traget.transform.position.x, transform.position.y, Traget.transform.position.z);

        // Make the zombie look at the target's X and Z position, ignoring Y-axis
        transform.LookAt(targetPosition); // Look at the target without moving up or down

        // Move forward only on the X and Z axes
        Vector3 direction = Vector3.forward;
        transform.Translate(direction * Time.deltaTime * speed, Space.Self); // Move relative to the zombie's own forward
    }

    private void AttackPlayer()
    {
        // Handle attack logic (e.g., reduce player's health)
        Debug.Log("Zombie is attacking the player!");
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage); // Reduce player's health
        }
    }

    private void Idle()
    {
        navAgent.SetDestination(transform.position); // Idle, no movement
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the chase and attack ranges in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}