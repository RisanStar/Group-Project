using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    public int sceneManagerIndex;
    private bool nextLvlAllowed;

    public Animator transition;
    public float transitionTime = 1f;

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
             StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
    
}
