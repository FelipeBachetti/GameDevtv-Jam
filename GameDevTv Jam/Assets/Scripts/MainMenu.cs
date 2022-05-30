using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("clickButton");
        SceneManager.LoadScene("Zombie");
        Time.timeScale = 1f;
    }
    
    public void Option()
    {
        FindObjectOfType<AudioManager>().Play("clickButton");
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("clickButton");
    }
}
