using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMechanics : MonoBehaviour

{
    private bool pickUpAllowed;
    public float pickUpTimer;
    private float pickUpCountdown = 0f;

    private bool canUse;


    void Start()
    {
        pickUpCountdown = pickUpTimer;
    }
    //PICKUP WITH E WITH TIMER
    private void Update()
    {
        if (pickUpAllowed && Input.GetKey(KeyCode.E))
        {
            pickUpCountdown -= 1f * Time.deltaTime;
        }
            
        if (pickUpCountdown <= 0f) { pickUpCountdown = 0f;}
        if (pickUpCountdown == 0f)
        {
            Pickup();
            canUse = true;
        }
               
    }

    //COLLISION WITH ITEM
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            pickUpAllowed = false;
        }
    }

    //PICKUP REFERENCE
    private void Pickup()
    {
        Destroy(GameObject.Find("Key"));
    } 
}
