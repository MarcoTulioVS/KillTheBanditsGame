using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public override void TakeDamage(int amount)
    {
        if (!isHited)
        {
            isHited = true;
            life -= amount * 1;
            Debug.Log(life);
            StartCoroutine("WaitTimeInvincible");
        }
    }

    IEnumerator WaitTimeInvincible()
    {
        yield return new WaitForSeconds(1f);
        isHited = false;
    }
}
