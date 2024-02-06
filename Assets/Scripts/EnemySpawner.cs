using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Pathfinding;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class EnemySpawner : MonoBehaviour
{
    private float DeathCount = 0f;
    public float DeathTimer;
    private bool canSpawn;
    public float speed;
    private float distance;
    public float distanceBetween;

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

        distance = Vector2.Distance(transform.position, enemyPrefab.transform.position);
        Vector2 direction = enemyPrefab.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, enemyPrefab.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }



    }

}
