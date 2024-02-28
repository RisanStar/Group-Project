using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    public int sceneManagerIndex;
    private bool nextLvlAllowed;

    [SerializeField] private GameObject startTrans;
    [SerializeField] private GameObject endTrans;

    private void Start()
    {
        startTrans.SetActive(true);
    }
    private void Update()
    {
        if (GameObject.FindWithTag("Key") == null)
        {
            nextLvlAllowed = true;
        }
        else
        {
            nextLvlAllowed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((nextLvlAllowed && collision.CompareTag("Player")))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
}
