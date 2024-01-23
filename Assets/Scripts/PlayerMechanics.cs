using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMechanics : MonoBehaviour

{
    private bool pickUpAllowed;
    public float Timer;
    private float Count = 0f;

    private bool canUseKey;
    private bool keyAllowed;

    private float doorSpeed;
    private int pointsIndex;
    [SerializeField] Transform[] Points;

    void Start()
    {
        Count = Timer;
        transform.position = Points[pointsIndex].transform.position;
    }
    //PICKUP WITH E WITH TIMER
    private void Update()
    {
        if (pickUpAllowed && Input.GetKey(KeyCode.E))
        {
            Count -= 1f * Time.deltaTime;
        }
            
        if (Count <= 0f) { Count = 0f;}
        if (Count == 0f && (pickUpAllowed))
        {
            Pickup();
            canUseKey = true;
        }
        
        if (keyAllowed && Input.GetKey(KeyCode.E))
        {
            Count -= 1f * Time.deltaTime;
        }
        if (Count == 0f && (keyAllowed))
        {
            
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

    private void OnTriggerEnter2D(Collider collision)
    {
        if (collision.CompareTag("Door") && (canUseKey))
        {
            keyAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider collision)
    {
        if (collision.CompareTag("Door") && (canUseKey))
        {
            keyAllowed = false;
        }
    }
    //PICKUP REFERENCE
    private void Pickup()
    {
        Destroy(GameObject.Find("Key"));
    } 
}
