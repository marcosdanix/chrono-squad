using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

    SpriteRenderer[] spriteRenderers;
    Rigidbody2D rb;
    public GameObject explosion;
    bool rewindCheck = false;
    bool startTimer = false;
    int timeSinceExplosion = 0;

    // Use this for initialization
    void Start () {
        spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void FixedUpdate () {
        

        if (Input.GetKey(KeyCode.E))
        {
            startTimer = false;
            rewindCheck = true;
            timeSinceExplosion--;
            if(timeSinceExplosion <= 0)
            {
                spriteRenderers[0].enabled = true;
                spriteRenderers[1].enabled = true;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R) && rewindCheck)
        {
            if(timeSinceExplosion <= 0)
            {
                rewindCheck = false;
                rb.velocity = Vector2.zero;
                rb.simulated = true;
            }
            
        }

        if (startTimer)
        {
            timeSinceExplosion++;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Ground")
        {
            rb.simulated = false;
            spriteRenderers[0].enabled = false;
            spriteRenderers[1].enabled = false;
            GameObject Explosion = (GameObject)Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            startTimer = true;
        }
    }
}
