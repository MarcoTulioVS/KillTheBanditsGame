using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private PlayerInput playerInput;

    private PlayerAnimation playerAnimation;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimation = GetComponent<PlayerAnimation>();
        
        playerInput.OnMovement += Movement;
    }
    

    
    void Update()
    {
        
    }

    private void Movement()
    {

        if (playerInput.Horizontal > 0)
        {
            playerAnimation.ExecuteAnimation(1);
            transform.position += transform.right * playerInput.Horizontal * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);

        }else if(playerInput.Horizontal < 0)
        {
            playerAnimation.ExecuteAnimation(1);
            transform.position -= transform.right * playerInput.Horizontal * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(playerInput.Horizontal == 0 && !playerAnimation.state)
        {
            playerAnimation.ExecuteAnimation(0);
            transform.position += Vector3.zero;
        }

    }
}
