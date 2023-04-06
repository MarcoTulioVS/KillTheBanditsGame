using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ControllerInput : MonoBehaviour
{
    public float Horizontal { get; set; }

    public bool AttackPower { get; set; }

    public event Action OnMovement;

    public event Action OnAttack;

    private ControllerHealth controllerHealth;
    
    private void Awake()
    {
        controllerHealth = GetComponent<ControllerHealth>();
    }


    void Update()
    {
        if (controllerHealth.health > 0)
        {
            InitializeInputs();
        }
    }

    private void InitializeInputs()
    {
        Horizontal = Input.GetAxis("Horizontal");
        AttackPower = Input.GetMouseButtonDown(0);

        OnMovement();

        if (AttackPower)
        {
            OnAttack();
        }
    }
}
