using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class CharacterHealth : MonoBehaviour
{
    public float health { get; set; }

    public int maxHealth { get; set; }

    public event Action OnDie;

    public Text lifeText;

    private CharacterAnimation characterAnimation;
    private void Awake()
    {
        maxHealth = 100;
        health = maxHealth;

        characterAnimation = GetComponent<CharacterAnimation>();
    }


    void Update()
    {
        Die();
        UpdateLife();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            DecrementHealth(10);
        }
    }
    private void Die()
    {
        if (health <= 0)
        {
            health = 0;
            characterAnimation.ExecuteAnimation(3);
            OnDie();
        }
    }

    private void DecrementHealth(float amount)
    {
        health -= amount;
    }
    private void UpdateLife()
    {
        lifeText.text = health.ToString();
    }
}
