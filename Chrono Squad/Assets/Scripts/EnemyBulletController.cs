﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "MainCamera")
        {
            rb.velocity = Vector2.zero;
            //gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
        if (col.gameObject.tag == "Player")
        {
            rb.velocity = Vector2.zero;
            col.gameObject.GetComponent<Player1Controller>().deathTrigger();
        }

//        if(col.gameObject.tag == "GhostPlayer")
//        {
//            rb.velocity = Vector2.zero;
//            col.gameObject.GetComponent<GhostReplay>().deathTrigger();
//        }


    }
}
