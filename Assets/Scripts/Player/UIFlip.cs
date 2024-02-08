using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    PlayerMovement playerMovement;


    public void Update()
    {
        playerMovement = GetComponent<PlayerMovement>();
       
        
    }
}
