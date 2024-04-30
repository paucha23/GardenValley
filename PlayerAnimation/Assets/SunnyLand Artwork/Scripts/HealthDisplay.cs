using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite cherry;
    public Image[] hearts;

    public PlayerHealth playerHealth;

    void Update()
    {
        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = cherry;
                hearts[i].enabled = true; // Enable the heart image
            }
            else
            {
                hearts[i].sprite = cherry;
                hearts[i].enabled = false; // Disable the heart image
            }
        }
    }
}
