﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "GhostPlayer")
        {
            gameObject.GetComponentInParent<EnemyController>().Attack();
        }
    }

    void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "GhostPlayer")
        {
            gameObject.GetComponentInParent<EnemyController>().Attack();
        }
    }
}
