using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CharacterInput : MonoBehaviour
{
    public float Horizontal { get; set; }

    public event Action OnMovement;

    public event Action OnAttack;

    private bool AttackSword;

    private CharacterHealth charHealth;

    private void Awake()
    {
        charHealth = GetComponent<CharacterHealth>();
    }


    void Update()
    {
        if (charHealth.health > 0)
        {
            InitializeInput();
        }
    }

    private void InitializeInput()
    {
        Horizontal = Input.GetAxis("Horizontal");
        AttackSword = Input.GetKeyDown(KeyCode.F);
        OnMovement();

        if (AttackSword)
        {
            OnAttack();
        }
    }
}
