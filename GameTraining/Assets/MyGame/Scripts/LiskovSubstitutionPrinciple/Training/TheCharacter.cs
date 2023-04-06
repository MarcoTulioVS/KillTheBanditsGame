using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCharacter : MonoBehaviour
{
    protected float life;

    private float currentLife;

    protected bool isHited;
    private void Awake()
    {
        life = 100;
        currentLife = life;
    }


    void Update()
    {
        
    }

    public virtual void TakeDamage(int amount)
    {
        currentLife -= amount;
        
    }

   
}
