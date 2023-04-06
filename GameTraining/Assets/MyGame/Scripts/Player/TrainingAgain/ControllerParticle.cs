using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerParticle : MonoBehaviour
{
    public GameObject particilePrefab;

    private GameObject obj;

    private bool particleOn;

    private void Awake()
    {
        GetComponent<ControllerHealth>().OnDie += ParticleDeath;
    }


    void Update()
    {
        
    }

    private void ParticleDeath()
    {
        
        if (obj == null && !particleOn)
        {
            particleOn = true;
            obj = Instantiate(particilePrefab, transform.position, Quaternion.identity);
        }
        Destroy(obj,2);
        
    }
}
