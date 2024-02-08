using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Pathfinding;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    private float DeathCount = 0f;
    public float DeathTimer;
    private bool canSpawn;
    public  float textSpeed;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] TextMeshProUGUI countTMPUGUI;

    void Start()
    {
        DeathCount = DeathTimer;
    }

    private void Update()
    {
        if (GameObject.FindWithTag("Enemy") == null)
        {
            DeathCount -= 1f * Time.deltaTime;
            countTMPUGUI.text = DeathCount.ToString("Hope: 0");

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
