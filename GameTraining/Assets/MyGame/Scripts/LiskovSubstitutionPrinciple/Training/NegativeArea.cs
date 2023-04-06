using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeArea : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        DealDamage();
    }

    private void DealDamage()
    {
        TheCharacter[] characters = FindObjectsOfType<TheCharacter>();
        
        foreach(TheCharacter character in characters)
        {
            float distance = Vector2.Distance(transform.position, character.gameObject.transform.position);
            

            if (distance <= 1.43f)
            {
                character.TakeDamage(2);
            }
        }
       
    }
}
