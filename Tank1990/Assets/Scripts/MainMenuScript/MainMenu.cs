using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<btnFX>().ClickSound();
        StartCoroutine(Wait());
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }
}
