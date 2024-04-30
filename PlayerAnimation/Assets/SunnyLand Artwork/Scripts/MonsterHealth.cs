using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int enemyHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = enemyHealth;
    }

    void Update()
    {
        if (currentHealth <- 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}