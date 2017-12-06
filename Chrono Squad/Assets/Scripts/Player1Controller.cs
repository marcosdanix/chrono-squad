using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour {

	public bool facingRight = true;
	public bool jump = false;

    public float maxSpeed = 300f;
	public float speed = 300f; 
    public float jumpForce;
	public Transform groundCheck;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public float chargeTimer = 0f;

	public bool grounded = false;
    public bool dead = false;
	private Animator anim;
	private Rigidbody2D rb2d;

    //shoot
    public GameObject projectile;
    public Vector2 velocity;
    Vector2 offset;
    Vector2 current_dir= Vector2.zero;
    int rotation;
    public Quaternion rotation_vec = Quaternion.identity;


	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
        Physics2D.IgnoreLayerCollision(0, 9);
        Physics2D.IgnoreLayerCollision(9, 9);
    }

    void Update ()
    {
        if (Time.timeScale == 0) {
            return;
        }

        offset = new Vector2(1.0f,1.0f);
        current_dir = Vector2.zero;

        if (Input.GetKey (KeyCode.E)) {
            return;
        } 

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            current_dir += Vector2.left;
        }
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            current_dir += Vector2.right;
        }

        if (Input.GetAxis("Vertical") < -0.1f && !grounded)
        {
            //transform.localScale = new Vector3(1, -1, 1);
            current_dir += Vector2.down;
        }
        if (Input.GetAxis("Vertical") > 0.1)
        {
            //transform.localScale = new Vector3(1, 1, 1);
            current_dir += Vector2.up;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            
             rb2d.AddForce(Vector2.up * Mathf.Sqrt(-2.0f * Physics2D.gravity.y * jumpForce), ForceMode2D.Impulse);
        }

        // ATTACKING
        bool canShoot = true;

        if (Input.GetButton("Fire1"))
        {
            chargeTimer += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1")&& canShoot)
        {
            if (current_dir == Vector2.zero)
            {
                current_dir = new Vector2(transform.localScale.x,0);
            }

            rotation = (int) Vector2.Angle(Vector2.right, current_dir);
            Vector3 cross = Vector3.Cross(transform.localScale, current_dir);

            if (cross.x > 0)
            {
                rotation = - rotation;
            }

            rotation_vec = Quaternion.Euler(0,0,rotation);

            if (chargeTimer > 2)
            {
                //chargeShot()
            }
            else
            {
                if (rotation == 45 || rotation == -45 || rotation == 135 || rotation == -135)
                {
                    velocity = new Vector2(50, 50);
                    offset = new Vector2(1.5f,2.5f);
                }
                else if (rotation == 90 || rotation == -90)
                {
                    velocity = new Vector2(0, 100);
                    offset = new Vector2(0.0f,4.0f);
                }
                else if (rotation == 0 || rotation == 180){
                    velocity = new Vector2(100, 0);
                }
                GameObject go = (GameObject)Instantiate(projectile, new Vector2(transform.position.x + offset.x * transform.localScale.x, transform.position.y + offset.y),rotation_vec); 
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x *velocity.x, current_dir.y * velocity.y);
            }
            chargeTimer = 0;
        }



    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        if (Input.GetKey (KeyCode.E)) {
            return;
        }
       //move player
        float h = Input.GetAxis("Horizontal");

        if (h == 0)
        {
            rb2d.velocity = new Vector2(h, rb2d.velocity.y);
        }


        if (grounded)
        {
            //rb2d.velocity = easeVelocity;
        }

        rb2d.AddForce((Vector2.right * speed) * h);

        //Limiting the speed
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        else if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            
        }

        //jump balacing gravity
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

    public void DoubleUp(){
        
    }
    public void deathTrigger(){
        if (Time.timeScale == 0) {
            return;
        }
        dead = true;
        anim.SetBool("dead", dead);
        gameObject.GetComponent<PauseTime>().SlowDown();
    }

    public void reviveTrigger(){
        dead = false;
        anim.SetBool("dead", dead);
        gameObject.GetComponent<PauseTime>().Normal();
    }

    void OnTriggerEnter2D(Collider2D col){
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "EnemyBullet")
        {
            deathTrigger();
        }
        else if (col.gameObject.tag == "Enemy_Missile")
        {
            deathTrigger();
        }
    }
}
