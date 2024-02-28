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
    private bool canLaunch;

    public float speed;
    public float verticalStrength;
    public float Timer;
    private float Count = 0f;

    [SerializeField] TextMeshProUGUI countTMPUGUI;
    [SerializeField] Canvas canvas;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject vent;
    [SerializeField] GameObject vent2;
    [SerializeField] GameObject vent3;
    [SerializeField] private AudioSource keySFX;


    void Start()
    {
        Count = Timer;
        countTMPUGUI.enabled = false;
        canvas.enabled = false;
        vent.SetActive(false);
        vent2.SetActive(false);
        vent3.SetActive(false);
    }
    //PICKUP WITH E WITH TIMER
    private void Update()
    {
        if (pickUpAllowed && Input.GetKey(KeyCode.E))
        {
            Count -= 1f * Time.deltaTime;
            keySFX.Play();

        }
            
        if (Count <= 0f) {Count = 0f;}
        if (Count == 0f && (pickUpAllowed))
        {
            Pickup();
        }

            if (GameObject.FindWithTag("Key") == null)
            {
                vent.SetActive(true);
                vent2.SetActive(true);
                vent3.SetActive(true);

            if (canLaunch)
            {
                transform.position += Vector3.up * verticalStrength * speed;
            }

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

        if (collision.CompareTag("LaunchPoint"))
        {
            canLaunch = true;
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

        if (collision.CompareTag("LaunchPoint"))
        {
            canLaunch = false;
        }
    }
    //PICKUP REFERENCE
    private void Pickup()
    {
        Destroy(GameObject.FindWithTag("Key"));
    }
}

