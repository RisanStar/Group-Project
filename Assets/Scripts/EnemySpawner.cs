using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float DeathCount = 0f;
    public float DeathTimer;
    private bool canSpawn;
    private bool hasSpawned;

    [SerializeField] private GameObject enemyPrefab;

    private void Start()
    {
        DeathCount = DeathTimer;
    }

    private void Update()
    {
        DeathCount -= 1f * Time.deltaTime;
        if (DeathCount <= 0f) { DeathCount = 0f;}
        if (DeathCount == 0f)
        {
            canSpawn = true;
        }
        else
        {
            canSpawn = false;
        }
   
        if (canSpawn)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            hasSpawned = true;
        }

        if (hasSpawned)
        {
            canSpawn = false;
        }
  
    }
    
}
