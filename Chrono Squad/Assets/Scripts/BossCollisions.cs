using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollisions : MonoBehaviour {

    int counter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update () {
	}

    void OnTriggerEnter2D(Collider2D col){
        if (Input.GetKey(KeyCode.E))
        {
            if (col.gameObject.tag == "Bullet")
            {
                gameObject.GetComponentInParent<BossController>().Regen(col.GetComponent<BulletController>().power);
                counter--;
                Debug.Log(counter);
            }
            return;
        }
        if (col.gameObject.tag == "Bullet")
        {
            counter++;
            gameObject.GetComponentInParent<BossController>().Attacked(col.GetComponent<BulletController>().power);
            Debug.Log(counter);
        }
    }
}
