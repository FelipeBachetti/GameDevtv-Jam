using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possession : MonoBehaviour
{
    [SerializeField] private int bodyType;
    [SerializeField] private GameObject zombie;

    private bool inRange;
    private GameObject player;

    private void Update() {
        if(inRange && Input.GetButtonDown("Possess")){
            player.SetActive(false);
            zombie.SetActive(true);
            zombie.GetComponent<abandonBody>().ghost = player;
            zombie.GetComponent<abandonBody>().originalPos = zombie.transform.position;

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
