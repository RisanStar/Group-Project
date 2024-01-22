using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMechanics : MonoBehaviour

{
    private bool pickUpAllowed;
    public float pickUpTimer = 0f;

    //PICKUP WITH E
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            while (Input.GetKeyDown(KeyCode.E))
                pickUpTimer = pickUpTimer + 1f;
        }
        {
            if (pickUpTimer > 3f)
            {
                Pickup();
            }
        }
    }

    //COLLISION WITH ITEM
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pickUpAllowed = false;
        }
    }

    //PICKUP REFERENCE
    private void Pickup()
    {
        Destroy(gameObject);
    } 
}
