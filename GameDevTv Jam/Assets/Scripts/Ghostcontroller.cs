using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostcontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    
    public GameObject cam;

    private Vector2 direction;
    private Animator anim;
    private float vertical, horizontal;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private bool facingRight = true;

    void Awake()
    {
        anim = GetComponent<Animator>();    
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        direction = new Vector2(horizontal, vertical) * Time.fixedDeltaTime * speed;
        rb.velocity = direction;
    }

    private void Update() {
        if(Mathf.Abs(horizontal) >= 0.01f){
            Flip(horizontal);
        }
    }

    private void Flip(float x){
        if((x<0 && facingRight)||(x>0 && !facingRight)){
            facingRight = !facingRight;
            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }
}
