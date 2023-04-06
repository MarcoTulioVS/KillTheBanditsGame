using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.UI;
public class PlayerHealthMG : MonoBehaviour
{
    public float health { get; set; }

    [SerializeField]
    private float maxHealth;

    public event Action OnDie;

    public Text healthText;

    private PlayerAnimationMG playerAnimation;

    private PlayerAttackMG playerAttack;
    void Awake()
    {
        health = maxHealth;
        playerAnimation = GetComponent<PlayerAnimationMG>();
        playerAttack = GetComponent<PlayerAttackMG>();
    }

    
    void Update()
    {
        Die();
        UpdateLife();
    }

    private void Die()
    {
        if(health <= 0)
        {
            health = 0;
            playerAnimation.ExecuteAnimation(3);
            OnDie();
        }
    }

    public void DecrementLife(float dmg)
    {
        if (!playerAttack.isAttacking)
        {
            health -= dmg;
        }
       
    }

    private void UpdateLife()
    {
        healthText.text = health.ToString();
    }

}
