using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private CharacterInput charInput;

    private CharacterAnimation characterAnimation;

    private void Awake()
    {
        charInput = GetComponent<CharacterInput>();
        characterAnimation = GetComponent<CharacterAnimation>();
        charInput.OnMovement += Movement;
    }


    void Update()
    {
        
    }

    private void Movement()
    {
        if (charInput.Horizontal > 0)
        {

            transform.position += transform.right * charInput.Horizontal * speed * Time.deltaTime;
            characterAnimation.ExecuteAnimation(1);
            transform.eulerAngles = new Vector3(0, 0, 0);

        }else if(charInput.Horizontal < 0)
        {
            transform.position -= transform.right * charInput.Horizontal * speed * Time.deltaTime;
            characterAnimation.ExecuteAnimation(1);
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else if(charInput.Horizontal == 0 && !characterAnimation.state)   
        {
            characterAnimation.ExecuteAnimation(0);
            transform.position += Vector3.zero;
        }
    }
}
