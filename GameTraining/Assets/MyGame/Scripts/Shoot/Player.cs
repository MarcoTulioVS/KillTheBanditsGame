using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private List<IWeapon> weaponList = new List<IWeapon>();
    public List<Rigidbody2D> weapons = new List<Rigidbody2D>();

    [SerializeField]
    private int indexWeapon;

    public Transform point;

    Fire fire = new Fire();
    Plasma plasma = new Plasma();

    
    private void Awake()
    {
        AddingWeapon(fire);
        AddingWeapon(plasma);

    }


    void Update()
    {
        CurrentWeapon();
        Fire();

        
    }

    public void AddingWeapon(IWeapon weapon)
    {
        weaponList.Add(weapon);
    }

    public void Fire()
    {
        if(weaponList != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
               
                Rigidbody2D rb = Instantiate(weapons[indexWeapon],point.position,weapons[indexWeapon].transform.rotation);
                weaponList[indexWeapon].Shoot(point,rb);

            }
        }
    }

    public void CurrentWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            indexWeapon++;
            
            if (indexWeapon > weaponList.Count - 1)
            {
                indexWeapon = 0;
            }
        }

    }

    
}
