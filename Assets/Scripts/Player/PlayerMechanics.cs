using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMechanics : MonoBehaviour

{
    //VARIABLES
    private bool pickUpAllowed;
    private bool buttondown;
    public float Timer;
    private float Count = 0f;

    [SerializeField] TextMeshProUGUI countTMPUGUI;
    [SerializeField] Canvas canvas;

    void Start()
    {
        Count = Timer;
        countTMPUGUI.enabled = false;
        canvas.enabled = false;

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
            countTMPUGUI.enabled = true;
            canvas.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            pickUpAllowed = false;
            countTMPUGUI.enabled = false;
            canvas.enabled = false;
        }
    }


    //PICKUP REFERENCE
    private void Pickup()
    {
        Destroy(GameObject.Find("Key"));
    }
}

