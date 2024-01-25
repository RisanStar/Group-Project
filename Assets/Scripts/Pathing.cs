using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pathing : MonoBehaviour
{
    //VARIABLES
    private bool canUseKey;
    public float doorSpeed;
    private int pointsIndex;
    [SerializeField] Transform[] Points;

    private void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    //USING KEY
    private void Update()
    {
        if (GameObject.FindWithTag("Key") == null)
        {
            canUseKey = true;
        }
        else
        {
            canUseKey = false;
        }
    
        if (canUseKey)
        {
            if(pointsIndex <= Points.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex + 1].transform.position, doorSpeed * Time.deltaTime);
                if(transform.position == Points[pointsIndex].transform.position)
                {
                    pointsIndex += 1;
                }

                
            }
        }
    }
}
