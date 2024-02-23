using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    private bool cutScene;
    public float Timer;
    private float Count = 0f;

    private void Start()
    {
        Count = Timer;
    }
    private void Update()
    {
        cutScene = true; 
        if (cutScene)
        {
            Count -= 1f * Time.deltaTime;
        }
        if (Count <= 0f) { Count = 0f; }
        if (Count == 0f)
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
