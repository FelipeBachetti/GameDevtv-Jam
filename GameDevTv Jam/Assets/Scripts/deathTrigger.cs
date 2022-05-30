using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathTrigger : MonoBehaviour
{
    public habilities hab;

    private void OnTriggerEnter2D(){
        hab.isFalling = false;
        Invoke("NextScene", 2f);
    }

    private void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
