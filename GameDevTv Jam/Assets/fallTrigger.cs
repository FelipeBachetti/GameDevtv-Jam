using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallTrigger : MonoBehaviour
{
    public Block b1,b2,b3,b4,b5,b6;
    public habilities hab;
    private void OnTriggerEnter2D(){
        b1.Break();
        b2.Break();
        b3.Break();
        b4.Break();
        b5.Break();
        b6.Break();
        hab.isFalling = true;
    }
}
