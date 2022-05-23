using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilities : MonoBehaviour
{
    [SerializeField] private int bodyType;
    [SerializeField] private Transform miningPoint;
    [SerializeField] private float miningRange;
    [SerializeField] private LayerMask breakableLayers;

    private bool isMining;
    private float cooldown = .5f;

    void Update()
    {
        switch(bodyType){
            case 0:
                break;
            case 1:
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
            isMining = false;
        }
    }

    public void Mine ()
    {
        Collider2D[] hitBlocks = Physics2D.OverlapCircleAll(miningPoint.position, miningRange, breakableLayers);
        foreach(Collider2D blocks in hitBlocks)
        {
            blocks.GetComponent<Block>().Break();
        }
        isMining = true;
        cooldown = 0f;
    }

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(miningPoint.position, miningRange);
    }
}
