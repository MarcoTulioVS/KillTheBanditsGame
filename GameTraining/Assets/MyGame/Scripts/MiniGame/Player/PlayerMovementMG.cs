using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMG : MonoBehaviour
{
    [Header("Walk")]
    [SerializeField]
    private float speed;

    [Header("Jump")]
    [SerializeField]
    private float jumpForce;

    private bool isJumping;

    private Rigidbody2D rb;

    private PlayerInputMG playerInput;

    private PlayerAnimationMG playerAnimation;

    private bool isStopped;
    private void Awake()
    {
        speed = 5;

        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInputMG>();
        playerAnimation = GetComponent<PlayerAnimationMG>();

        playerInput.OnMovement += Movement;
        playerInput.OnJump+=Jump;
    }


    void Update()
    {
        
    }

    private void Movement()
    {
        if(playerInput.Horizontal > 0)
        {
            isStopped = false;

            if (!isJumping)
            {
                playerAnimation.ExecuteAnimation(1);
            }
            
            transform.position += transform.right * playerInput.Horizontal * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if(playerInput.Horizontal < 0)
        {
            isStopped=false;

            if (!isJumping)
            {
                playerAnimation.ExecuteAnimation(1);
            }
            
            transform.position -= transform.right * playerInput.Horizontal * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(playerInput.Horizontal == 0 && !playerAnimation.state && !isStopped)
        {
            isStopped = true;
            playerAnimation.ExecuteAnimation(0);
            transform.position += Vector3.zero;
        }
    }

    private void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            StartCoroutine(playerAnimation.ExecuteAnimation(4,0.3f,0));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ground
        if (collision.gameObject.layer==10)
        {
            isJumping=false;
        }
    }
}
