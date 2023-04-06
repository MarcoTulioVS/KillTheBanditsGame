using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    private SpawnCollection spawnCollection;
    
    void Start()
    {
        spawnCollection = GameObject.FindGameObjectWithTag("SpawnCollection").GetComponent<SpawnCollection>();
    }

    
    void Update()
    {
        
    }

    public void DecrementEnemyQuantity()
    {
        for (int i = 6; i < 8; i++)
        {
            if (gameObject.layer == i)
            {
                if (spawnCollection.spawnList[i-6].GetComponent<SpawnEnemy>().spawn.countEnemy>=1)
                {
                    spawnCollection.spawnList[i - 6].GetComponent<SpawnEnemy>().spawn.countEnemy--;
                    
                }
                
            }
        }
    }

    private void OnDisable()
    {
        GameController.instance.scoreValue += 10;
    }
}
