using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    float timer = 0.8f;
    Rigidbody2D rb;
    Vector3 init_position;
    SpriteRenderer spriteRenderer;
    BoxCollider2D collider;
    Animator animator;
    public bool destroy = true;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        init_position = gameObject.transform.position;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        collider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy) {
           Destroy();
        }
    }

    public void Destroy()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            spriteRenderer.enabled = false;
            collider.enabled = false;
            destroy = false;
            animator.SetBool("Exploded", true);

            //Destroy(gameObject);
        }
    }
}
