using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class DeathTransition : MonoBehaviour
{
    public Animator transition;
    private bool doTransition;
    public float transitionTime = 1f;

    public Rigidbody2D Noah;

    private void Start()
    {
        Noah.GetComponent<Rigidbody2D>();
        if (Noah.bodyType == RigidbodyType2D.Static)
        {
            doTransition = true;
        }
        else
        {
            doTransition = false;
        }
    }
    private void Update()
    {
        if (doTransition)
        {
            Restart();
        }
    }
    private void Restart()
    {
        StartCoroutine((LoadLevel(SceneManager.GetActiveScene().buildIndex)));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }


}
