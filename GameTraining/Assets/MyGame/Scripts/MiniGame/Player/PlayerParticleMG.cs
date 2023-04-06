using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleMG : MonoBehaviour
{
    public GameObject particleDeathPrefab;

    private GameObject obj;

    private bool particleOn;

    private PlayerHealthMG playerHealth;
    void Awake()
    {
        playerHealth = GetComponent<PlayerHealthMG>();
        playerHealth.OnDie += ParticleDeath;
    }

    
    void Update()
    {
        
    }

    private void ParticleDeath()
    {
        if(obj == null && !particleOn)
        {
            particleOn = true;
            obj = Instantiate(particleDeathPrefab,transform.position,Quaternion.identity);
        }
        Destroy(obj, 2);
    }
}
