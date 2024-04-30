using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public float KBTime = 0.2f;
    public float hitDirectionForce = 10f;
    public float constForce = 5f;
    public float inputForce = 7.5f;

    public bool isBeingKB {  get; private set; }

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); 
    }

    private IEnumerator KBAction(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        isBeingKB = true;

        Vector2 _hitForce;
        Vector2 _constantForce;
        Vector2 _KBForce;
        Vector2 _combinedForce;

        _hitForce = hitDirection * hitDirectionForce;
        _constantForce = constantForceDirection * constForce;


        float _elapsedTime = 0f;
        while(_elapsedTime < KBTime)
        {
            _elapsedTime += Time.fixedDeltaTime; 

            _KBForce = _hitForce + _constantForce;

            if(inputDirection != 0)
            {
                _constantForce = _KBForce + new Vector2(inputDirection, 0f);
            }
            else
            {
                _combinedForce = _KBForce;  
            }

            playerRB.velocity = _KBForce;

            yield return new WaitForFixedUpdate();
        }

        isBeingKB = false;
    }
}
