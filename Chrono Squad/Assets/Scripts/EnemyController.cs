using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject player;
    public GameObject projectile;
    Animator anim;
    public float hp = 100f;
    
    float nextFire = 0;
    float fireRate = 0.1f;
    float fireBreak = 2;
    float awakeBreak = 2f;
    float deathBreak = 2f;

    int counter = 0;
    int[] offsety = new int[11] {0,1,0,1,0,1,0,1,0,1,0};

    public Vector2 velocity;
    public Vector2 offset;

    public bool dead = false;
    public bool shooting = false;
    public bool awake = false;
    public int teste = 0;


	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0 && awake)
        {
            dead = true;
            anim.SetBool("Dead", true);
            Die(); 
        }
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 50 && !awake)
        {
            anim.SetBool("Awake", true);
            Awake();
        }
        if (distance < 30 && awake && !dead)
        {
            MachineGun();
        }
        else if (shooting == true && awake && !dead)
        {
            MachineGun();
        }
	}

    public void Attacked(float damage){
        hp -= damage;
    }


    public void Awake()
    {
       if(awakeBreak > 0)
       {
           awakeBreak -= Time.deltaTime;     
       }
       else
       {
           awake = true;
       }
    }

    public void Die()
    {
        if (deathBreak > 0)
        {
            deathBreak -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    public void MachineGun()
    {
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
                GameObject go = (GameObject)Instantiate(projectile, new Vector2(transform.position.x + offset.x, transform.position.y + offsety[counter]), Quaternion.identity); 
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * -1, velocity.y);
            }
        }
    }
}
