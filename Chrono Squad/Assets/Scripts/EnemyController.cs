using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject player;
    public GameObject projectile;
    Animator anim;

    public static float HP = 100f;
    public static float HP_BAR_SIZE = 7.2f;

    public float hp;
    bool dead = false;
    float nextFire = 0;
    float fireRate = 0.1f;
    float fireBreak = 2;
    int counter = 0;
    int[] offsety = new int[11] {0,1,0,1,0,1,0,1,0,1,0};

    public Vector2 velocity;
    public Vector2 offset;
    public bool shooting = false;

    float hp_dif;
    float hpbar_x;

    [Header ("Unity Stuff")]
    public Image hpBar;

	// Use this for initialization
	void Start () {
        hp = HP;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0)
        {
            dead = true;
            anim.SetBool("Dead", dead);
            //Destroy(gameObject);
        }
        else if (hp > 0)
        {
            dead = false;
            anim.SetBool("Dead", dead);
        }

        if (Input.GetKey(KeyCode.E))
        {
            MachineGun();
            return;
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 40)
        {
            MachineGun();
        }
        else if (shooting == true)
        {
            MachineGun();
        }
	}

    public void Attacked(float damage){
        hp -= damage;
        Debug.Log(hp);
        hpBar.fillAmount = hp / HP;
    }

    public void Regen(float damage){
        hp += damage;
        Debug.Log(hp);
        hpBar.fillAmount = hp / HP;
    }


    public void MachineGun()
    {
        if (dead)
        {
            return;
        }
        if (Input.GetKey(KeyCode.E))
        {
            
            return;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {

        }
        if (counter == 10)
        {
            anim.SetBool("Shoot", false);
            fireBreak -= Time.deltaTime;
            if (fireBreak <= 0)
            {
                counter = 0;
                fireBreak = 2;
                shooting = false;
            }
        }
        else
        {
            shooting = true;
            if (Time.time > nextFire)
            {
                anim.SetBool("Shoot", true);
                counter++;
                nextFire = Time.time + fireRate;
                Debug.Log("oi");
                GameObject go = (GameObject)Instantiate(projectile, new Vector2(transform.position.x + offset.x, transform.position.y + offsety[counter]), Quaternion.identity); 
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * -1, velocity.y);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        //Debug.Log(col.gameObject.tag);
        if (Input.GetKey(KeyCode.E))
        {
            if (col.gameObject.tag == "Bullet")
            {
                Regen(col.GetComponent<BulletController>().power);
            }
            return;
        }
        if (col.gameObject.tag == "Bullet")
        {
            Attacked(col.gameObject.GetComponent<BulletController>().power);
        }
    }
}
