using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public float health { get; set; }

    public float maxHealth { get; set; }

    public event Action OnDie;

    public Text lifeText;

    private PlayerAnimation playerAnimation;
    private void Awake()
    {
        maxHealth = 100;
        health = maxHealth;

        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            DecrementHealth(10);
        }
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

    private void DecrementHealth(float value)
    {
        health -= value;
    }

    private void UpdateLife()
    {
        lifeText.text = health.ToString();
    }
}
