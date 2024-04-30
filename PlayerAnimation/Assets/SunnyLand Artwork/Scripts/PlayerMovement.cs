using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public Animator animator;

    public float speed;
    public float crouchSpeed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    public float jumpTime = 0.35f;
    public float jumpTimeCounter;

    private bool isJumping;
    private bool isCrouching;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KBFromRight;

    public bool flippedLeft;
    public bool facingRight;


    private void Start()
    {

    }
    void Update()
    {
        if (KBCounter <= 0)
        {
            input = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(input));
        }
        else
        {
            float knockbackDirection = KBFromRight ? -1 : 1;
            playerRB.velocity = new Vector2(knockbackDirection * KBForce, playerRB.velocity.y);

            KBCounter -= Time.deltaTime;
        }

        //Movement*********************************


       

        //Jump**************************************

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRB.velocity = Vector2.up * jumpForce;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                playerRB.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                animator.SetBool("IsJumping", false);
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }


        //Crouch****************************************

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("IsCrouching", true);
            isCrouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("IsCrouching", false);
            isCrouching = false;
        }
    }
    void FixedUpdate()
    {
        if (input < 0)
        {
            facingRight = false;
            Flip(false);
        }
        else if (input > 0)
        {
            facingRight = true;
            Flip(true);
        }

        float currentSpeed = isCrouching ? crouchSpeed : speed;
        if (KBCounter > 0)
        {
            float knockbackDirection = KBFromRight ? -1 : 1;
            playerRB.velocity = new Vector2(knockbackDirection * KBForce, playerRB.velocity.y);
        }
        else
        {
            playerRB.velocity = new Vector2(input * currentSpeed, playerRB.velocity.y);
        }
    }
    void Flip(bool facingRight)
    {
        if (flippedLeft && facingRight)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = false;
        }
        if (!flippedLeft && !facingRight)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = true;
        }
    }
}