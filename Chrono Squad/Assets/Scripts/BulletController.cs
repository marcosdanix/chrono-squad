using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    Rigidbody2D rb;
    BoxCollider2D cc;
    Animator anim;
    public float power=25f;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cc = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.E))
        {
            //cc.isTrigger = false;
            return;
            //return;
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            //cc.isTrigger = true;
        }
	}

    void OnTriggerEnter2D(Collider2D col){
        if (Input.GetKey(KeyCode.E))
        {
            return;
            //return;
        }
        if (col.gameObject.tag == "MainCamera")
        {
            rb.velocity = Vector2.zero;
            //gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }

    }
}
