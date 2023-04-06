using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAttack : MonoBehaviour
{
    public Transform pointAttack;

    [SerializeField]
    private float colliderRadius;

    private ControllerAnimation controllerAnimation;

    private ControllerMovement ControllerMovement;
    private void Awake()
    {
        GetComponent<ControllerInput>().OnAttack += Attack;

        controllerAnimation = GetComponent<ControllerAnimation>();

        ControllerMovement = GetComponent<ControllerMovement>();
    }


    void Update()
    {
        
    }

    private void Attack()
    {
        Collider2D col = Physics2D.OverlapCircle(pointAttack.position, colliderRadius);
        
        if (col != null && !ControllerMovement.isMoving)
        {
            StartCoroutine(controllerAnimation.ExecuteAnimation(2, 0.5f, 1,true));
            Destroy(col.gameObject,0.5f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pointAttack.position,colliderRadius);
    }
}
