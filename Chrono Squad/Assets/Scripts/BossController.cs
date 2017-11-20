using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public float hp = 1000;
    public float laser_timer = 10;
    public float laser_on = 0f;
    Animator anim;
    Animator anim3;
    Animator anim2;
    BoxCollider2D col;
	// Use this for initialization
	void Start () {
        anim = gameObject.transform.Find("Laser").GetComponent<Animator>();
        anim.SetFloat("timer", laser_timer);
        anim2 = gameObject.transform.Find("Laser_cont").GetComponent<Animator>();
        col = gameObject.transform.Find("Laser_cont").GetComponent<BoxCollider2D>();
        col.enabled = false;
        anim2.SetFloat("timer", laser_timer);

        anim3 = gameObject.transform.Find("Boss Head").GetComponent<Animator>();
        anim3.SetFloat("timer", laser_timer);
	}
	
	// Update is called once per frame
	void Update () {


        if (hp <= 0)
        {
            //dead = true;
            //anim.SetBool("Dead", true);
            Destroy(gameObject);
        }   

        if (laser_timer < 0)
        {
            col.enabled = true;
            anim.SetFloat("timer", laser_timer);
            anim2.SetFloat("timer", laser_timer);
            anim3.SetFloat("timer", laser_timer);
            laser_timer = 10;
            laser_on = 0.6f;
            Shoot_Laser();
        }
        else if (laser_on < 0)
        {
            col.enabled = false;
            anim.SetFloat("timer", laser_timer);
            anim2.SetFloat("timer", laser_timer);
            anim3.SetFloat("timer", laser_timer);
            laser_timer = laser_timer - Time.deltaTime;

        }
        else
        {
            laser_on= laser_on - Time.deltaTime ;
        }
    }

    void Shoot_Laser(){
    
    }

    public void Attacked(float damage){
        Debug.Log(hp);
        hp -= damage;
    }
}
