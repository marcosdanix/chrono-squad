using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{

    Rigidbody2D rb;
    Vector3 init_position;
    SpriteRenderer spriteRenderer;
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        init_position = gameObject.transform.position;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //animators = gameObject.GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Ground")
        {
            rb.velocity = Vector2.zero;
            spriteRenderer.enabled = false;
            //gameObject.layer = 0;
            //col.gameObject.GetComponent<Player1Controller>().deathTrigger();
            GameObject Explosion = (GameObject)Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //grenade.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * -1, velocity.y);
        }

        //        if(col.gameObject.tag == "GhostPlayer")
        //        {
        //            rb.velocity = Vector2.zero;
        //            col.gameObject.GetComponent<GhostReplay>().deathTrigger();
        //        }


    }

    void OnTriggerExit2D(Collider2D col)
    {
        //if (col.gameObject.tag == "EnemyRange")
        //{
         //   rb.velocity = Vector2.zero;
           // gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //}
    }
}
