using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenSoldierController : MonoBehaviour
{

    Rigidbody2D rb;
    public GameObject player;
    public GameObject projectile;
    Animator anim;
    public bool dead = false;

    public static float HP = 20f;
    public static float HP_BAR_SIZE = 7.2f;

    public float hp;
    //bool dead = false;
    float nextFire = 0;
    float fireRate = 0.1f;
    float fireBreak = 5;
    int counter = 0;
    int[] offsety = new int[11] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };

    public Vector2 velocity;
    public Vector2 offset;
    Vector3 theScale;
    public bool throwGrenade = false;
    public bool inRange = false;
    float directionFace;
    float Speed = 5.0f;
    public SpriteRenderer[] spriteRenderers;

    float hp_dif;
    float hpbar_x;

    [Header("Unity Stuff")]
    public Image hpBar;

    // Use this for initialization
    void Start()
    {
        hp = HP;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
        //spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void FixedUpdate()
    {

        directionFace = player.transform.position.x - transform.position.x;


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
            Attack();
            return;
        }
        if (throwGrenade == true)
        {
            Attack();
        }

        if(!inRange) //move towards the player if not in range
        {
            
            if (directionFace <= 0)
            {
                transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.Self);
                //spriteRenderers[0].flipX = true;
                

                //facingRight = !facingRight;
               
            }
            else
            {
                transform.Translate(Vector3.right * Time.deltaTime * Speed, Space.Self);
                //spriteRenderers[0].flipX = true;
                theScale = transform.localScale;
                theScale.x = -1;
                transform.localScale = theScale;
            }
        }
    }

    public void Attacked(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / HP;
    }

    public void Regen(float damage)
    {
        hp += damage;
        Debug.Log(hp);
        hpBar.fillAmount = hp / HP;
    }


    public void Attack()
    {
        if (dead)
        {
            return;
        }
        if (Input.GetKey(KeyCode.E))
        {
            throwGrenade = false;
            counter = 0;
            anim.SetBool("Throw", false);
            anim.SetBool("InRange", false);
            return;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {

        }
        if (counter == 1)
        {
            anim.SetBool("Throw", false);
            //anim.SetBool("InRange", false);
            fireBreak -= Time.deltaTime;
            if (fireBreak <= 0)
            {
                counter = 0;
                fireBreak = 3;
                throwGrenade = true;
            }
        }
        else
        {
            anim.SetBool("Throw", true);
            counter = 1;
            GameObject grenade = (GameObject)Instantiate(projectile, new Vector2(transform.position.x + offset.x, transform.position.y + offset.y), Quaternion.identity);
            grenade.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * Math.Sign(directionFace), velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.tag);
        if (Input.GetKey(KeyCode.E))
        {
        }
        if (col.gameObject.tag == "Bullet")
        {
            Attacked(col.gameObject.GetComponent<BulletController>().power);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (col.gameObject.tag == "Bullet")
            {
                Regen(col.GetComponent<BulletController>().power);
            }
            return;
        }

    }

    public void PrepareThrow() //currently throws grenade everytime he is in range
    {
        throwGrenade = true;
        anim.SetBool("InRange", true);
        inRange = true;
    }

    public void OutOfRange()
    {
        throwGrenade = false;
        anim.SetBool("InRange", false);
        inRange = false;
    }
}
