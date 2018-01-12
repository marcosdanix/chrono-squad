using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;
    float posX;
    public bool bossFightInPosition = false;
    float bossFightInitialPosition = 392;
    public Vector2 offset = new Vector2();

    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!bossFightInPosition)
        {
            posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
            transform.position = new Vector3(posX, 0, transform.position.z);
        }
        
    }  

    void OnTriggerEnter2D(Collider2D col){
        if (Input.GetKey(KeyCode.E))
        {
            if (col.gameObject.tag == "Bullet")
            {

            }
            return;
        }
        if (col.gameObject.tag == "Bullet")
        {
            col.gameObject.GetComponent<BulletController>().setStop();   
        }
    }     
}
