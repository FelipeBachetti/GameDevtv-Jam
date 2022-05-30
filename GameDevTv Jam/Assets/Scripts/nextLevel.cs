using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private Animator anim;
    private GameObject Transition;
    [SerializeField] private float timer;

    private void OnTriggerEnter2D(Collider2D other) {
        Transition = GameObject.Find("LoadingPanel");
        anim = Transition.GetComponent<Animator>();
    }

    private void Update(){
        if(Transition != null){
            timer -= Time.deltaTime;
            if(timer<=0){
                Proceed();
            }
        }
    }

    public void Proceed(){
        anim.SetTrigger("FadeIn");
        Invoke("NextScene", .5f);
    }

    void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
