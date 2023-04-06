using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
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
        Character[] characters = FindObjectsOfType<Character>();

        foreach (Character character in characters)
        {
            float distance = Vector2.Distance(character.transform.position,transform.position);
            
            if (distance <= 1.96f)
            {
                character.TakeDamage(2);
            }
        }
        
        
    }

    
}
