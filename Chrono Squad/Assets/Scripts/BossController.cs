using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossController : MonoBehaviour {
    public GameObject missile;
    public GameObject soldier;
    public GameObject hpBar;
    public GameObject soundController; //access to soundController so it can play the victory tune
    public GameObject bossFightManager;

    public static float HP = 3000;
    public static float HP_BAR_SIZE = 179;
    public static float LASER_TIMER = 10;
    public static float LASER_DURATION = 0.6f;

    public bool dead = false;
    public bool startCounters = false;
    bool soldierSpawn = false;
    bool missileSpawn = false;
    Vector3 position;

    float laser_on = 0f;
    float hp;
    float laser_timer;
    Animator anim;
    Animator anim3;
    Animator anim2;
    Animator anim4;
    Animator anim5;
    Animator anim6;
    Animator anim7;
    Animator anim8;

    float hp_dif;
    float hpbar_x;

    
    BoxCollider2D col;
    float rewind=1.0f;
	// Use this for initialization
	void Start () {
        hp = HP;
        laser_timer = LASER_TIMER;
        laser_on = 0f;

        //meter isto num animator talvez
        anim = gameObject.transform.Find("Laser").GetComponent<Animator>();
        anim.SetFloat("timer", laser_timer);
        anim2 = gameObject.transform.Find("Laser_cont").GetComponent<Animator>();
        col = gameObject.transform.Find("Laser_cont").GetComponent<BoxCollider2D>();
        col.enabled = false;
        anim2.SetFloat("timer", laser_timer);
        anim3 = gameObject.transform.Find("Boss Head").GetComponent<Animator>();
        anim3.SetFloat("timer", laser_timer);
        anim4 = gameObject.transform.Find("Boss Body").GetComponent<Animator>();
        anim5 = gameObject.transform.Find("Boss Right Arm").Find("Boss Right Arm").Find("Boss Right Arm Joint 2").GetComponent<Animator>();
        anim6 = gameObject.transform.Find("Boss Right Arm").Find("Boss Right Arm").Find("Boss Right Arm Joint 3").GetComponent<Animator>();
        anim7 = gameObject.transform.Find("Boss Right Arm").Find("Boss Right Arm").Find("Boss Right Arm Joint 4").GetComponent<Animator>();
        anim8 = gameObject.transform.Find("Boss Right Arm").Find("Boss Claw").GetComponent<Animator>();

        anim.SetFloat("rewind", rewind);
        anim2.SetFloat("rewind", rewind);
        anim3.SetFloat("rewind", rewind);
        anim4.SetFloat("rewind", rewind);
        anim5.SetFloat("rewind", rewind);
        anim6.SetFloat("rewind", rewind);
        anim7.SetFloat("rewind", rewind);
        anim8.SetFloat("rewind", rewind);

	}
	
	// Update is called once per frame
	void Update () {
        /* if (Input.GetKey(KeyCode.E))
        {
            anim.SetFloat("rewind", -rewind);
            anim2.SetFloat("rewind", -rewind);
            anim3.SetFloat("rewind", -rewind);
            anim4.SetFloat("rewind", -rewind);
            anim5.SetFloat("rewind", -rewind);
            anim6.SetFloat("rewind", -rewind);
            anim7.SetFloat("rewind", -rewind);
            anim8.SetFloat("rewind", -rewind);

            if (laser_on < LASER_DURATION && startCounters)
            {
                laser_on += Time.deltaTime;
            }
            else if (startCounters)
            {
                anim.SetFloat("timer", laser_timer);
                anim2.SetFloat("timer", laser_timer);
                anim3.SetFloat("timer", laser_timer);
                if (laser_timer < LASER_TIMER)
                {
                    laser_timer += Time.deltaTime;
                }
            }

        }
        else
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                anim.SetFloat("rewind", rewind);
                anim2.SetFloat("rewind", rewind);
                anim3.SetFloat("rewind", rewind);
                anim4.SetFloat("rewind", rewind);
                anim5.SetFloat("rewind", rewind);
                anim6.SetFloat("rewind", rewind);
                anim7.SetFloat("rewind", rewind);
                anim8.SetFloat("rewind", rewind);

            }

            if (laser_timer < 0 && startCounters)
            {
                col.enabled = true;
                anim.SetFloat("timer", laser_timer);
                anim2.SetFloat("timer", laser_timer);
                anim3.SetFloat("timer", laser_timer);
                laser_timer = LASER_TIMER; //Don't restart, the fight should end in less than 10 seconds
                laser_on = LASER_DURATION;
                Shoot_Laser();
            }
            else if (laser_on < 0 && startCounters)
            {
                col.enabled = false;
                anim.SetFloat("timer", laser_timer);
                anim2.SetFloat("timer", laser_timer);
                anim3.SetFloat("timer", laser_timer);
                laser_timer = laser_timer - Time.deltaTime;

            }
            else if (startCounters)
            {
                laser_on= laser_on - Time.deltaTime ;
            }
            
        }*/

        if(Time.timeScale == 0){
            return;
        }

        if (hp <= 0)
        {
            soundController.GetComponent<SoundManager>().bossDead = true;
            bossFightManager.GetComponent<BossFightManager>().bossDead = true;
            hpBar.GetComponent<RectTransform>().offsetMax = new Vector2(10.5f, -184f);
            Destroy(gameObject);
        }  
    }

    void FixedUpdate()
    {

        if (startCounters)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (laser_timer < LASER_TIMER)
                {
                    laser_timer += Time.deltaTime;
                    anim.SetFloat("timer", laser_timer);
                    anim2.SetFloat("timer", laser_timer);
                    anim3.SetFloat("timer", laser_timer);
                }
            }         
            else
            {
                if (laser_timer < 0)
                {
                    col.enabled = true;
                    anim.SetFloat("timer", laser_timer);
                    anim2.SetFloat("timer", laser_timer);
                    anim3.SetFloat("timer", laser_timer);
                }           
                else if(laser_timer < 4 && !soldierSpawn)
                {
                    soldierSpawn = true;
                    position = new Vector3(transform.position.x - 20, -9, transform.position.z);
                    Instantiate(soldier, position, Quaternion.identity);

                    position = new Vector3(transform.position.x + 20, -9, transform.position.z);
                    Instantiate(soldier, position, Quaternion.identity);

                }
                else if (laser_timer < 8 && !missileSpawn)
                {
                    missileSpawn = true;
                    position = new Vector3(transform.position.x-4, 20, transform.position.z);
                    Instantiate(missile, position, Quaternion.identity);

                    position = new Vector3(transform.position.x - 16, 20, transform.position.z);
                    Instantiate(missile, position, Quaternion.identity);

                    position = new Vector3(transform.position.x + 4, 20, transform.position.z);
                    Instantiate(missile, position, Quaternion.identity);

                    position = new Vector3(transform.position.x + 16, 20, transform.position.z);
                    Instantiate(missile, position, Quaternion.identity);

                }
                else
                {
                    laser_timer -= Time.deltaTime;
                }
            }            
        }
    }

    void Shoot_Laser(){
    
    }

    public void Attacked(float damage){
        hp -= damage;
        hp_dif = 1 - (hp / HP);
        hpBar.GetComponent<RectTransform>().offsetMax = new Vector2(10.5f, -5 - (HP_BAR_SIZE*hp_dif));
    }

    public void Regen(float damage){
        if(hp < HP)
        {
            hp += damage;
            hp_dif = 1 - (hp / HP);
            Debug.Log(hp);
            hpBar.GetComponent<RectTransform>().offsetMax = new Vector2(10.5f, -5 - (HP_BAR_SIZE * hp_dif));
        }
       
    }
}
