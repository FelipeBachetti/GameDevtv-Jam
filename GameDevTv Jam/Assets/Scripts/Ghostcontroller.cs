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
}
