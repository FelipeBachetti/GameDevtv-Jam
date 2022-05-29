using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float jumpforce;
    public CircleCollider2D col;
    public habilities hab;
    public GameObject death;

    float direction;

    private Vector2 facingRight;
    private Vector2 facingLeft;
    private Animator anim;
    private float timer;

    private bool isJumping, grounded1, grounded2, willDie;

    [SerializeField] private LayerMask whatIsGround1, whatIsGround2;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float Radius;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        anim = GetComponent<Animator>();
        timer = .5f;
    }

    // Update is called once per frame

    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        if(direction > 0 && rb.velocity.y == 0)
        {
            transform.localScale = facingRight;
        }
        if(direction < 0 && rb.velocity.y == 0)
        {
            transform.localScale = facingLeft;
        }
        if (rb.velocity.y == 0 && Input.GetKeyDown(KeyCode.Space)) //if the player is not mid air and "space" is pressed, then jump
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isJumping = true;
        }
        if(Mathf.Abs(direction)>0.01){
            anim.SetBool("isWalking", true);
        }else{
            anim.SetBool("isWalking", false);
        }
        if(!isJumping){
            anim.SetBool("isJumping", false);
        }else{
            anim.SetBool("isJumping", true);
        }
        if(Mathf.Abs(rb.velocity.y)<=0.01){
            isJumping = false;
            if(willDie){
                Die();
            }
        }

        if(rb.velocity.y < -0.01){
            timer -= Time.deltaTime;
        }else{
            timer = .5f;
        }

        if(timer <= 0){
            willDie = true;
        }

        grounded1 = Physics2D.OverlapCircle(GroundCheck.position, Radius, whatIsGround1);
        grounded2 = Physics2D.OverlapCircle(GroundCheck.position, Radius, whatIsGround2);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundCheck.position, Radius);
    }

    private void Die(){
        anim.SetTrigger("isDead");
        col.enabled = false;
        hab.enabled = false;
        death.SetActive(true);
        this.enabled = false;
    }
}
