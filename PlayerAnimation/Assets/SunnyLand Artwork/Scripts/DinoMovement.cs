using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    public Transform[] patrolPoints; 
    public float patrolSpeed; 
    public float chaseSpeed; 
    public float chaseDistance; 
    public LayerMask playerLayer;

    private int currentPatrolIndex = 0; 
    private Transform player; 
    private bool isChasing = false; 

    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        animator = GetComponent<Animator>();
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
        if (!isChasing && Vector2.Distance(transform.position, player.position) <= chaseDistance)
        {
            StartChase();
        }
        if (isChasing && Vector2.Distance(transform.position, player.position) > chaseDistance)
        {
            StopChase();
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolIndex].position, patrolSpeed * Time.deltaTime);

        FlipSprite(transform.position.x < patrolPoints[currentPatrolIndex].position.x);

        if (Vector2.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        FlipSprite(transform.position.x < player.position.x);
    }

    private void StartChase()
    {
        isChasing = true;
        animator.SetBool("IsChasing", true);
    }

    private void StopChase()
    {
        isChasing = false;
        animator.SetBool("IsChasing", false);
    }

    private void FlipSprite(bool faceLeft)
    {
        Vector3 scale = transform.localScale;
        scale.x = faceLeft ? -6f : 6f;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartChase();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopChase();
        }
    }
}
