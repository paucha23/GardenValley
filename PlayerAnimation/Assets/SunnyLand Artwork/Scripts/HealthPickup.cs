using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float healthBonus = 1;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerHealth.health < playerHealth.maxHealth)
        {
            Destroy(gameObject);
            playerHealth.health = (int)(playerHealth.health + healthBonus);
        }
    }
}
