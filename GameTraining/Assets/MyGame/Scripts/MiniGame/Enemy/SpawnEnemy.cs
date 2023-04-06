using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Spawn spawn;

    public static SpawnEnemy instance;

    private GameObject obj;
    private void Awake()
    {
        instance = this;

        spawn.countEnemy = 0;
    }
    void Start()
    {
        StartCoroutine("Spawn");
    }

    
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        if (spawn.countEnemy < 1)
        {
            obj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            obj.layer = gameObject.layer; 
            spawn.countEnemy++;

        }

        yield return new WaitForSeconds(5);
        StartCoroutine("Spawn");
    }
}
