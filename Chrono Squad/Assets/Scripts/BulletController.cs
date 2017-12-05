using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    Rigidbody2D rb;
    BoxCollider2D cc;
    Animator anim;
    public float power=25f;

    public bool dead = false;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cc = gameObject.GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.E))
        {
            //cc.isTrigger = false;
            return;
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
        }
        if (col.gameObject.tag == "MainCamera")
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("stop", true);
            //gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }

        if (col.gameObject.tag == "Enemy")
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("stop", true);
            //col.gameObject.GetComponent<Player1Controller>().deathTrigger();
        }

    }

    void OnTriggerExit2D(Collider2D col){
        if(Input.GetKey(KeyCode.E)){
            if (col.gameObject.tag == "MainCamera")
            {
                anim.SetBool("stop", false);
                //gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            }

            if (col.gameObject.tag == "Enemy")
            {
                anim.SetBool("stop", false);
                //col.gameObject.GetComponent<Player1Controller>().deathTrigger();
            }
        }
    }

    public void setStop(){
        anim.SetBool("stop", true);
    }
}
