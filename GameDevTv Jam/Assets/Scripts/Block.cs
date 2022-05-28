using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int resistance;
    [SerializeField] private SpriteRenderer breakingSprite;
    [SerializeField] private Sprite sprite01, sprite02;

    private ParticleSystem particle;
    private SpriteRenderer thisSprite;

    private void Awake() {
        particle = GetComponentInChildren<ParticleSystem>();
        thisSprite = GetComponent<SpriteRenderer>();
    }

    public void Break(){
        resistance--;
        if(resistance==0){
            thisSprite.enabled = false;
            breakingSprite.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            particle.Play();
            Invoke("Destructor", 1f);
        }else if(resistance == 2){
            breakingSprite.sprite = sprite01;
        }else{
            breakingSprite.sprite = sprite02;
        }
    }

    private void Destructor(){
        Destroy(gameObject);
    }
}
