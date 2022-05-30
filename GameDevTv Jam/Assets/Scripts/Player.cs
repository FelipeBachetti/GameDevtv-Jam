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
    private float initialPos, finalPos, animationTimer=.6f;

    private float timer = 0.5f;

    private bool isJumping, willDie, hasInitialPos;
    [SerializeField] private bool autoAwake;
    [SerializeField] private float maxFallHeight;

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

        if(autoAwake){
            anim.SetBool("autoAwake", true);
        }else if(animationTimer>0){
            direction = 0f;
            animationTimer -= Time.deltaTime;
        }

        if(direction > 0 && rb.velocity.y == 0)
        {
            transform.localScale = facingRight;
        }
        if(direction < 0 && rb.velocity.y == 0)
        {
            transform.localScale = facingLeft;
        }
        if (Mathf.Abs(rb.velocity.y)<=0.01 && Input.GetButtonDown("Jump")) //if the player is not mid air and "space" is pressed, then jump
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isJumping = true;
            FindObjectOfType<AudioManager>().Play("Jumping");
        }
        if(Mathf.Abs(direction)>0.01){
            anim.SetBool("isWalking", true);
            if (timer >= .5f)
            {
                FindObjectOfType<AudioManager>().Play("WalkingInGrass");
            }
            timer = 0f;
        }
        else{
            anim.SetBool("isWalking", false);
            timer = .5f;
            FindObjectOfType<AudioManager>().StopSound("WalkingInGrass");
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
                if(!hasInitialPos){
                    initialPos = transform.position.y;
                    hasInitialPos = true;
                }else{
                    finalPos = transform.position.y;
                }
        }else{
            if(hasInitialPos){
                hasInitialPos = false;
                if(initialPos - finalPos > maxFallHeight){
                    willDie = true;
                }
            }
        }

        if(timer <= 0)
        {
            timer += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    private void Die(){
        rb.velocity = new Vector2(0, 0);
        anim.SetBool("isJumping", false);
        anim.SetTrigger("isDead");
        col.enabled = false;
        hab.enabled = false;
        death.SetActive(true);
        this.enabled = false;
    }
}
