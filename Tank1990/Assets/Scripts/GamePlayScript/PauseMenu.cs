using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
     //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        FindObjectOfType<Player_Movement>().enabled = false;
    }

    public void Resume()
    {
        FindObjectOfType<btnFX>().ClickSound();
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<Player_Movement>().enabled = true;
    }
    public void LoadMenu()
    {
        FindObjectOfType<btnFX>().ClickSound();
        SceneManager.LoadScene("MenuGame");
        Resume();
    }
    public void QuitGame()
    {
        Debug.Log("Quitting!");
        Application.Quit();
    }
}
