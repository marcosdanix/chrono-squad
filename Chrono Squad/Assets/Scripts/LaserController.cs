using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player1Controller>().deathTrigger();
        }
    }

    void OnTriggerStay2D(Collider2D col){
        
    }
}
