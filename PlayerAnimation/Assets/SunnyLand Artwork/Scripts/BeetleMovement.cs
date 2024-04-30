using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPoints; // Array to hold reference to patrol points
    public float patrolSpeed = 2f; // Speed at which the enemy patrols
    public float chaseSpeed = 4f; // Speed at which the enemy chases the player
    public float chaseDistance = 5f; // Distance at which the enemy starts chasing the player
    public LayerMask playerLayer; // Layer mask for the player

    private int currentPatrolIndex = 0; // Index of current patrol point
    private Transform player; // Reference to the player transform
    private bool isChasing = false; // Flag to indicate if the enemy is currently chasing the player

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object
    }

    private void Update()
    {
        if (!isChasing)
        {
            Patrol();
        }
        else
        {
            Chase();
        }

        // Check if the player is within chase distance
        if (!isChasing && Vector2.Distance(transform.position, player.position) <= chaseDistance)
        {
            StartChase();
        }

        // Check if the player is out of chase distance
        if (isChasing && Vector2.Distance(transform.position, player.position) > chaseDistance)
        {
            StopChase();
        }
    }

    private void Patrol()
    {
        // Move towards the current patrol point
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolIndex].position, patrolSpeed * Time.deltaTime);

        // Flip the sprite based on movement direction
        FlipSprite(transform.position.x < patrolPoints[currentPatrolIndex].position.x);

        // Check if the enemy has reached the patrol point
        if (Vector2.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length; // Move to the next patrol point
        }
    }

    private void Chase()
    {
        // Move towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        // Flip the sprite based on movement direction
        FlipSprite(transform.position.x < player.position.x);
    }

    private void StartChase()
    {
        isChasing = true;
    }

    private void StopChase()
    {
        isChasing = false;
    }

    private void FlipSprite(bool faceLeft)
    {
        Vector3 scale = transform.localScale;
        scale.x = faceLeft ? -4f : 4f;
        transform.localScale = scale;
    }

    // Check for collision with the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartChase();
        }
    }

    // Check when the player exits chase range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopChase();
        }
    }
}
