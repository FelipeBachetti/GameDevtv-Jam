using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private int direction;
    private bool move;
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private BoxCollider2D leftCol, rightCol;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Push(float dir){
        if(dir>=0){
            direction = 1;
        }else{
            direction = -1;
        }
        move = true;
    }

    void FixedUpdate()
    {
        if(move){
            rb.velocity = new Vector2(speed*Time.deltaTime*direction, 0);
        }


    }
}
