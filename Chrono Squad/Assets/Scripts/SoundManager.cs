using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    AudioSource source;
    Collider2D checkpoint;
    Collider2D playerCollider;
    public AudioClip[] clips;
    public GameObject player;
    

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        checkpoint = GetComponentInChildren<Collider2D>();
        source.clip = clips[0];
        source.Play();
        playerCollider = player.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //OnTriggerEnter2D(checkpoint);
        if (checkpoint.IsTouching(playerCollider))
        {
            source.clip = clips[1];
            source.Play();
        }
	}

}
