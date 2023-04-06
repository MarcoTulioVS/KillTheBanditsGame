using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{

    public Transform pointAttack;
    public float colliderRadius;

    private CharacterAnimation characterAnimation;
    private void Awake()
    {
        GetComponent<CharacterInput>().OnAttack += Attack;
        characterAnimation = GetComponent<CharacterAnimation>();
    }

    void Update()
    {
        
    }

    private void Attack()
    {
        Collider2D col = Physics2D.OverlapCircle(pointAttack.position, colliderRadius);

        if (col != null)
        {
            StartCoroutine(characterAnimation.ExecuteAnimation(2, 0.667f, 0,true));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pointAttack.position, colliderRadius);
    }
}
