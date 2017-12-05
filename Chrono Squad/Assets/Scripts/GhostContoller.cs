using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostContoller : MonoBehaviour {

    Animator anim;
    public bool saved;
    bool dead;
    GameObject deathBullet;
    public bool already_died;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        dead = false;
        saved = false;
        already_died = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.E)){
            if(!already_died){
                rewindTrigger();
            }
        }
		
	}

    void OnTriggerEnter2D(Collider2D col){
        //Debug.Log(col.gameObject.tag);
        if(Input.GetKey(KeyCode.E)){

        }
        else
        {
            if (col.gameObject.tag == "EnemyBullet")
            {
                if (!already_died)
                {
                    if (!dead)
                    {
                        deathBullet = col.gameObject;
                        deathTrigger();
                    }
                }
                else
                {
                    if (col.gameObject.name.Equals(deathBullet.name))
                    {
                        deathTrigger();
                    }
                }

            }
            else if (saved == true && col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<Player1Controller>().DoubleUp();

                //Destroy(gameObject);
            }
        }    
    }

    void onTriggerExit2D(Collider2D col){
        if (Input.GetKey(KeyCode.E))
        {
            if (col.gameObject.tag == "EnemyBullet")
            {
                if (already_died)
                {
                    if (col.gameObject.name.Equals(deathBullet.name))
                    {
                        rewindTrigger();
                    }
                }
                else
                {
                }
            }
        }
    }

    public void deathTrigger(){
        dead = true;
        saved = false;
        already_died = true;
        anim.SetBool("save", saved);
        anim.SetBool("dead", dead);
    }

    public void rewindTrigger(){
        saved = false;
        dead = false;
        anim.SetBool("save", saved);
        anim.SetBool("dead", dead);
    }

    public void Saved(){
        if (!dead)
        {
            already_died = false;
            saved = true;
            anim.SetBool("save", saved);
            anim.SetBool("dead", dead);
        }
    }
}
