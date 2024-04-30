using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    public int damageDeal;

    public Rigidbody2D playerRB;
    public float bounceForce;

    private void Start()
    {
        playerRB = transform.parent.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "KillPoint")
        {
            other.gameObject.GetComponent<MonsterHealth>().TakeDamage(damageDeal);
            playerRB.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}