using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("Clicking");
        SceneManager.LoadScene("Level0");
        Time.timeScale = 1f;
    }
    
    public void Option()
    {
        FindObjectOfType<AudioManager>().Play("Clicking");
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("Clicking");
    }
}
