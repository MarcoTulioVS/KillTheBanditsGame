using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : Character
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
            life -= amount * 2;
            Debug.Log(life);
            StartCoroutine("WaitTimeInvincible");
        }
        
    }

    IEnumerator WaitTimeInvincible()
    {
        yield return new WaitForSeconds(2);
        isHited = false;
    }
}
