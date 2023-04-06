using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plasma : IWeapon
{
    public float speed { get; set ; }
    
    public Plasma()
    {
        this.speed = 5;
    }
    public void Shoot(Transform point,Rigidbody2D rb)
    {
        rb.velocity = new Vector2(speed,rb.velocity.y);    
        
    }
}
