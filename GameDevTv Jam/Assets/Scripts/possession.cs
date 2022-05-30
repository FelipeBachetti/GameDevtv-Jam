using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class possession : MonoBehaviour
{
    [SerializeField] private int bodyType;
    [SerializeField] private abandonBody zombie;

    private bool inRange;
    private GameObject player;

    [SerializeField] private GameObject SFX;
    [SerializeField] private GameObject col;

    //private GameObject ghost;

    
    private void Update() {
        if(inRange && Input.GetButtonDown("Possess")){
            FindObjectOfType<AudioManager>().Play("Ghost");
            //ghost =  GameObject.Find("LoadingPanel");
            //ghost.GetComponent<AudioManager>().Play("Ghost");
            if (col != null)
                Destroy(col);
            zombie.cam = player.GetComponent<Ghostcontroller>().cam;
            player.SetActive(false);
            zombie.gameObject.SetActive(true);
            zombie.ghost = player;
            zombie.originalPos = zombie.transform.position;
            zombie.SFX = SFX;
            SFX.SetActive(false);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            inRange = true;
            player = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            inRange = false;
        }
    }
}
