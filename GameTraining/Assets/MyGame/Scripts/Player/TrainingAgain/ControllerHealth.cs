using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ControllerHealth : MonoBehaviour
{
    public float health { get; set; }

    public float maxHealth { get; set; }

    public event Action OnDie;

    public Text lifeText;

    private ControllerAnimation controllerAnimation;

    private void Awake()
    {
        maxHealth = 100;
        health = maxHealth;

        controllerAnimation = GetComponent<ControllerAnimation>();
    }


    void Update()
    {
        Die();
        UpdateLife();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            DecrementLife(10);
        }
    }
    private void Die()
    {
        if(health <= 0)
        {
            health = 0;
            controllerAnimation.ExecuteAnimation(3);
            OnDie();
        }
    }

    private void DecrementLife(float amount)
    {
        health -= amount;
    }

    private void UpdateLife()
    {
        lifeText.text = health.ToString();
    }
}
