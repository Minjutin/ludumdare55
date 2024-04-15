using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{

    public void ReturnMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void InfiniteGame()
    {
        GameManager.instance.infinite = true;
        Time.timeScale = 1f;
        GameManager.instance.NextLevel();
        this.gameObject.SetActive(false);
    }
}
