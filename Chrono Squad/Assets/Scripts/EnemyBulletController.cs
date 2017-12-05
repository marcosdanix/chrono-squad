using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

    Rigidbody2D rb;
    Vector3 init_position;
    public bool dead = false;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        init_position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.E))
        {

        }

    }

    void OnTriggerEnter2D(Collider2D col){

        if (col.gameObject.tag == "Player")
        {
            rb.velocity = Vector2.zero;
            //col.gameObject.GetComponent<Player1Controller>().deathTrigger();
        }

//        if(col.gameObject.tag == "GhostPlayer")
//        {
//            rb.velocity = Vector2.zero;
//            col.gameObject.GetComponent<GhostReplay>().deathTrigger();
//        }


    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "EnemyRange")
        {
            rb.velocity = Vector2.zero;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
