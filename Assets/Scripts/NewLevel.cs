using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    public int sceneManagerIndex;
    private bool nextLvlAllowed;

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

        if (GameObject.FindWithTag("Player") == null)
        {
            Restart();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((nextLvlAllowed && collision.CompareTag("Player")))
        {
            SceneManager.LoadScene(sceneManagerIndex, LoadSceneMode.Single);
        }
    }
    
}
