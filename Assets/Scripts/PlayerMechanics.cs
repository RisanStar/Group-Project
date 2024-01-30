using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMechanics : MonoBehaviour

{
    //VARIABLES
    private bool pickUpAllowed;
    public float Timer;
    private float Count = 0f;

    void Start()
    {
        Count = Timer;
    }
    //PICKUP WITH E WITH TIMER
    private void Update()
    {
        if (pickUpAllowed && Input.GetKey(KeyCode.E))
        {
            Count -= 1f * Time.deltaTime;
        }
            
        if (Count <= 0f) {Count = 0f;}
        if (Count == 0f && (pickUpAllowed))
        {
            Pickup();
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

