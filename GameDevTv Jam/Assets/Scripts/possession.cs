using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possession : MonoBehaviour
{
    [SerializeField] private int bodyType;
    [SerializeField] private abandonBody zombie;

    private bool inRange;
    private GameObject player;

    
    private void Update() {
        if(inRange && Input.GetButtonDown("Possess")){
            zombie.cam = player.GetComponent<Ghostcontroller>().cam;
            player.SetActive(false);
            zombie.gameObject.SetActive(true);
            zombie.ghost = player;
            zombie.originalPos = zombie.transform.position;
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
