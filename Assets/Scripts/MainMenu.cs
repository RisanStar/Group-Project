using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //private GameObject StartOn;
    //private GameObject StartOff;

    private void Start()
    {
        //StartOff = GameObject.Find("StartButtonOff");
        //StartOn = GameObject.Find("StartButton");
    }
    public void PlayGame()
    {
        //StartOff.SetActive(false);
        //StartOn.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToControls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
