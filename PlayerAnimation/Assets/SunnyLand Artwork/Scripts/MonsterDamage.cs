using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage = 1;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerHealth != null && playerMovement != null)
        {
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerMovement.KBFromRight = true;
            }
            else
            {
                playerMovement.KBFromRight = false;
            }
            playerHealth.TakeDamage(damage);
        }
    }
}

