using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public Transform player;           // Reference to the player
    public float speed = 2f;           // Movement speed
    public float chaseRange = 20f;     // Distance within which zombies chase
    public float attackRange = 2f;     // Distance for attack
    private Rigidbody2D rb;            // Rigidbody2D for 2D movement
    private Vector2 wanderTarget;      // Target for wandering behavior
    private float wanderRadius = 5f;   // Radius for wandering
    private float wanderTimer = 3f;    // Time interval for choosing a new wander target
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = wanderTimer;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // Stop moving to "attack" the player
            rb.velocity = Vector2.zero;
        }
        else if (distanceToPlayer <= chaseRange)
        {
            // Chase the player
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        else
        {
            // Wander when the player is out of chase range
            Wander();
        }
    }

    void Wander()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized * wanderRadius;
            wanderTarget = (Vector2)transform.position + randomDirection;
            timer = 0;
        }

        Vector2 direction = (wanderTarget - (Vector2)transform.position).normalized;
        rb.velocity = direction * speed * 0.5f; // Wander at a slower speed
    }
}
