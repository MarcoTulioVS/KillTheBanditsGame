using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }

    public bool AttackSword { get; private set; }

    public event Action OnAttack;

    public event Action OnMovement;

    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth.health > 0)
        {
            InitializeInputs();
        }
        
    }

    private void InitializeInputs()
    {
        Horizontal = Input.GetAxis("Horizontal");
        OnMovement();
        AttackSword = Input.GetButtonDown("Fire1");

        if (AttackSword)
        {
            OnAttack();
        }
    }
}
