using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject LoseMenuUI;
    public void SetActive()
    {
        LoseMenuUI.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuGame");
        Resume();
    }
    public void QuitGame()
    {
        Debug.Log("Quitting!");
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Resume();
    }
}
