using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    public GameObject particleDeathPrefab;

    private GameObject obj;

    private bool particleOn;
    private void Awake()
    {
        GetComponent<PlayerHealth>().OnDie += ParticleDeath;
    }
    
    void Update()
    {
        
    }

    private void ParticleDeath()
    {
        if (obj == null && !particleOn)
        {
            particleOn = true;
            obj = Instantiate(particleDeathPrefab, transform.position, Quaternion.identity);
        }
        Destroy(obj,2);
    }
}
