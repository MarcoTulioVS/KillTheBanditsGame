using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public void Shoot(Transform point, Rigidbody2D rb);

    public float speed { get; set; }
}
