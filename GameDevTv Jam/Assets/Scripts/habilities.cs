using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilities : MonoBehaviour
{
    [SerializeField] private int bodyType;
    [SerializeField] private Transform miningPoint, punchPoint, firePoint;
    [SerializeField] private float miningRange, punchRange;
    [SerializeField] private LayerMask breakableLayers, pushableLayers;
    [SerializeField] private GameObject bulletPrefab;

    private bool isActing;
    private float cooldown = .5f;
    public Animator anim;

    public bool isFalling;

    private void Awake() {
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        switch(bodyType){
            case 0:
                if (Input.GetButtonDown("Fire1") && cooldown >= .25f)
		        {
			        Shoot();
		        }
                break;
            case 1:
                if(Input.GetButtonDown("Fire1") && cooldown >= .25f){
                    Punch();
                }
                break;
            case 2:
                if(Input.GetButtonDown("Fire1") && cooldown >= .25f){
                    Mine();
                }
                break;
            case 3:
                if(isFalling){
                    GetComponent<Player>().enabled = false;
                    anim.SetBool("isFalling", true);
                }else{
                    anim.SetBool("isFalling", false);
                }
                break;
        }
        if(cooldown < 0.25f){
            cooldown += Time.deltaTime;
        }else{
            isActing = false;
        }

        if(isActing){
            anim.SetTrigger("isAttacking");
        }
    }

    public void Mine ()
    {
        Collider2D[] hitBlocks = Physics2D.OverlapCircleAll(miningPoint.position, miningRange, breakableLayers);
        foreach(Collider2D blocks in hitBlocks)
        {
            blocks.GetComponent<Block>().Break();
            FindObjectOfType<AudioManager>().Play("Jumping");
        }
        isActing = true;
        cooldown = 0f;
    }

    public void Punch ()
    {
        anim.SetTrigger("isAttacking");
        Collider2D[] hitBlocks = Physics2D.OverlapCircleAll(punchPoint.position, punchRange, pushableLayers);
        foreach(Collider2D blocks in hitBlocks)
        {
            blocks.GetComponent<Box>().Push(blocks.transform.position.x - transform.position.x);
        }
        isActing = true;
        cooldown = 0f;
    }

    void Shoot ()
	{
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if(transform.localScale.x<0){
            bullet.transform.localScale *= -1; 
            bullet.GetComponent<Bullet>().isRight = false;
        }
	}

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(miningPoint.position, miningRange);
    }
}
