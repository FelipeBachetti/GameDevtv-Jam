using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public Rigidbody2D rb;
    public bool isRight = true;

	void FixedUpdate () {
        if(isRight){
		    rb.velocity = transform.right * speed * Time.fixedDeltaTime;
        }else{
            rb.velocity = -transform.right * speed * Time.fixedDeltaTime;
        }
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		button but = hitInfo.GetComponent<button>();
		if (but != null)
		{
			but.Press();
		}
        if(!hitInfo.isTrigger)
            Destroy(gameObject);
	}
	
}
