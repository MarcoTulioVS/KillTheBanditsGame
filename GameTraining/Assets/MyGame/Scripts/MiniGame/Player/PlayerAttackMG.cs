using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMG : MonoBehaviour
{
    private PlayerInputMG playerInput;

    public Transform pointAttack;

    [SerializeField]
    private float radiusAttack;

    private PlayerAnimationMG playerAnimation;

    public SpawnCollection spawnCollection;

    public bool isAttacking;
    
    void Awake()
    {
        playerInput = GetComponent<PlayerInputMG>();
        playerAnimation = GetComponent<PlayerAnimationMG>();
        playerInput.OnAttack += Attack;

        
    }

    
    void Update()
    {
        
    }

    private void Attack()
    {
        
        Collider2D col = Physics2D.OverlapCircle(pointAttack.position, radiusAttack);
        
        if (col != null)
        {
            if (col.gameObject.tag == "enemy")
            {
                isAttacking = true;
                StartCoroutine(playerAnimation.ExecuteAnimation(2, 0.583f, 0, true));
                col.GetComponent<EnemyDie>().DecrementEnemyQuantity();
                Destroy(col.gameObject, 1f);
                StartCoroutine("ResetAttack");
            }
        }
        

        
    }


    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(2);
        isAttacking = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pointAttack.position, radiusAttack);
    }
}
