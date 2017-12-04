using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostContoller : MonoBehaviour {

    Animator anim;
    public bool saved;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        saved = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col){
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "EnemyBullet")
        {
            //deathTrigger();
        }
        else if (saved == true && col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player1Controller>().DoubleUp();

            //Destroy(gameObject);
        }
    }

    public void deathTrigger(){
        saved = false;
        anim.SetBool("save", saved);
    }

    public void setSaved(){
        saved = false;
        anim.SetBool("save", saved);
    }

    public void Saved(){
        saved = true;
        anim.SetBool("save", saved);
    }
}
