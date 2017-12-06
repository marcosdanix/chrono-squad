using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

    public Animator[] animators;
    public SpriteRenderer[] spriteRenderers;

    float deathBreak = 1.5f;
    public Vector2 velocity;
    public Vector2 offset;
    public bool destroy = false;

    // Use this for initialization
    void Start () {
        spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        animators = gameObject.GetComponentsInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (destroy)
        {
            Destroy();
        }
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(col.gameObject.tag);
             //if (col.gameObject.tag == "MainCamera")
        spriteRenderers[0].enabled = false;
        animators[1].SetBool("Explode", true);
        destroy = true;
        gameObject.layer = 0;
    }

    public void Destroy()
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
}
