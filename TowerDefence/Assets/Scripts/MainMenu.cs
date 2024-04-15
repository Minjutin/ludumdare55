using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    // Called when we click the "Play" button.
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }
    // Called when we click the "Quit" button.
    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnMiljaBtn()
    {
        Application.OpenURL("https://minjutin.itch.io/");
    }

    public void OnTeemuBtn()
    {
        Application.OpenURL("https://6knowledge.itch.io/");
    }

    public void OnToniBtn()
    {
        Application.OpenURL("https://itch.io/profile/insanitum");
    }


}
