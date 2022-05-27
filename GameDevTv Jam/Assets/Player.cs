using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float jumpforce;

    float direction;

    private Vector2 facingRight;
    private Vector2 facingLeft;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        if(direction > 0 && rb.velocity.y == 0)
        {
            transform.localScale = facingRight;
        }
        if(direction < 0 && rb.velocity.y ==0)
        {
            transform.localScale = facingLeft;
        }
        if (rb.velocity.y == 0 && Input.GetKeyDown(KeyCode.Space)) //if the player is not mid air and "space" is pressed, then jump
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
        if(Mathf.Abs(direction)>0.01){
            anim.SetBool("isWalking", true);
        }else{
            anim.SetBool("isWalking", false);
        }
        if(Mathf.Abs(rb.velocity.y)<0.01){
            anim.SetBool("isJumping", false);
        }else{
            anim.SetBool("isJumping", true);
        }
    }

    void FixedUpdate()
    {
       if (rb.velocity.y == 0) //player just can move if grounded
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        }

    }
}
