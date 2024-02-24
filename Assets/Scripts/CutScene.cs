using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public float sceneTime;

   private void Update()
    {
       sceneTime -= Time.deltaTime;
        if(sceneTime <= 0)
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
