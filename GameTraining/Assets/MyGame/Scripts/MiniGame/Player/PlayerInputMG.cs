using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerInputMG : MonoBehaviour
{
    public float Horizontal { get; set; }

    private bool AttackSword;

    private bool inputJump;

    public event Action OnMovement;

    public event Action OnAttack;

    public event Action OnJump;

    private PlayerHealthMG playerHealth;


    void Awake()
    {
        playerHealth = GetComponent<PlayerHealthMG>();
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

        AttackSword = Input.GetMouseButton(0);

        inputJump = Input.GetKeyDown(KeyCode.Space);

        if (AttackSword)
        {
            OnAttack();
        }

        if (inputJump)
        {
            OnJump();
        }
    }
}
