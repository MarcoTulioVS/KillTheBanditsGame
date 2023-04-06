using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : IWeapon
{
    public float speed { get; set ; }
    
    public Fire()
    {
        this.speed = 8;
    }
    public void Shoot(Transform point, Rigidbody2D rb)
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
