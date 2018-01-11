using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public GameObject explosion;
    bool rewindCheck = false;
    bool startTimer = false;
    int timeSinceExplosion = 0;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E))
        {
            startTimer = false;
            rewindCheck = true;
            timeSinceExplosion--;
            if (timeSinceExplosion <= 0)
            {
                spriteRenderer.enabled = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.R) && rewindCheck)
        {
            if (timeSinceExplosion <= 0)
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
            rb.velocity = Vector2.up;
            spriteRenderer.enabled = false;
            GameObject Explosion = (GameObject)Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            startTimer = true;
        }
    }
}
