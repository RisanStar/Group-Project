using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    void Update()
    {
        if (aiPath.desiredVelocity.x >= .01f)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (aiPath.desiredVelocity.x <= -.01f)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
    }
}
