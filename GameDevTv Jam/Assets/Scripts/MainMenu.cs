using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        FindObjectOfType<AudioManager>().Play("Soundtrack");
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Level0");
        Time.timeScale = 1f;
    }
    
    public void Option()
    {
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
