using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilities : MonoBehaviour
{
    [SerializeField] private int bodyType;
    [SerializeField] private Transform miningPoint, punchPoint;
    [SerializeField] private float miningRange, punchRange;
    [SerializeField] private LayerMask breakableLayers, pushableLayers;

    private bool isActing;
    private float cooldown = .5f;
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        switch(bodyType){
            case 0:
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
                break;
        }
        if(cooldown < 0.25f){
            cooldown += Time.deltaTime;
        }else{
            isActing = false;
        }
    }

    public void Mine ()
    {
        Collider2D[] hitBlocks = Physics2D.OverlapCircleAll(miningPoint.position, miningRange, breakableLayers);
        foreach(Collider2D blocks in hitBlocks)
        {
            blocks.GetComponent<Block>().Break();
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

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(punchPoint.position, punchRange);
    }
}
