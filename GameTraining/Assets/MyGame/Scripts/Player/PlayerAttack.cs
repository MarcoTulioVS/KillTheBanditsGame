using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform pointAttack;
    public float colliderRadius;

    private PlayerAnimation playerAnimation;

    private void Awake()
    {
        GetComponent<PlayerInput>().OnAttack += Attack;
        playerAnimation = GetComponent<PlayerAnimation>();
    }
    
    void Update()
    {
        
    }

    private void Attack()
    {
        //Colocar a layer no Physics2D
        
        Collider2D col = Physics2D.OverlapCircle(pointAttack.position, colliderRadius);
        
        if(col != null)
        {
            Debug.Log(col.name);
            StartCoroutine(playerAnimation.ExecuteAnimation(2,0.583f,0,true));
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pointAttack.position, colliderRadius);
    }
}
