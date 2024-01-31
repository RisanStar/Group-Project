using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float DeathCount = 0f;
    public float DeathTimer;
    private bool canSpawn;

    [SerializeField] private GameObject enemyPrefab;

    void Start()
    {
        DeathCount = DeathTimer;
    }

    private void Update()
    {
        if (GameObject.FindWithTag("Enemy") == null)
        {
            DeathCount -= 1f * Time.deltaTime;
            if (DeathCount <= 0f) { DeathCount = 0f; }
            if (DeathCount == 0f)
            {
                canSpawn = true;
            }

            if (canSpawn)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            }
        }
        else
        {
            canSpawn = false;
        }

    }
     



}
