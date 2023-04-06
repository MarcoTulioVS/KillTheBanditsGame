using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private ControllerInput controllerInput;

    private ControllerAnimation controllerAnimation;

    public bool isMoving { get; private set; }

    private void Awake()
    {
        controllerInput = GetComponent<ControllerInput>();
        controllerInput.OnMovement += Movement;

        controllerAnimation = GetComponent<ControllerAnimation>();
    }


    void Update()
    {
        
    }

    private void Movement()
    {
        if (controllerInput.Horizontal > 0)
        {
            isMoving = true;
            controllerAnimation.ExecuteAnimation(1);
            transform.position += transform.right * controllerInput.Horizontal * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (controllerInput.Horizontal < 0)
        {
            isMoving = true;
            controllerAnimation.ExecuteAnimation(1);
            transform.position -= transform.right * controllerInput.Horizontal * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(controllerInput.Horizontal == 0 && !controllerAnimation.state)
        {
            isMoving = false;
            controllerAnimation.ExecuteAnimation(0);
            transform.position += Vector3.zero;

        }
    }
}
