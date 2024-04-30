using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 5;

    public SpriteRenderer playerSR;
    public PlayerMovement playerMovement;

    private bool hasDied = false;

    void Start()
    {
        health = maxHealth;
    }

    [System.Obsolete]
    public void TakeDamage(int damage)
    {
        if (!hasDied)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        hasDied = true;
        playerMovement.enabled = false;
        playerSR.enabled = false;
        Time.timeScale = 0f;

        StartCoroutine(ReloadLevelAfterDelay(1f));
    }

    IEnumerator ReloadLevelAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
