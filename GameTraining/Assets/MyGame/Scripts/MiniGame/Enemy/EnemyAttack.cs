using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform pointAttack;

    [SerializeField]
    private float radiusAttack;

    private PlayerHealthMG playerHealth;

    public bool isAttacking { get; private set; }

    private PlayerInputMG playerInput;

    void Awake()
    {
        GetComponent<EnemyMovement>().OnAttack += Attack;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthMG>();
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputMG>();

    }

    
    void Update()
    {
        
    }

    private void Attack()
    {
        Collider2D col = Physics2D.OverlapCircle(pointAttack.position, radiusAttack);
        
        if (col != null)
        {
            if (col.gameObject.tag == "Player" && !isAttacking)
            {

                StartCoroutine("DealDamage");
               
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pointAttack.position, radiusAttack);
    }

    IEnumerator DealDamage()
    {
        
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);
        playerHealth.DecrementLife(20);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}
