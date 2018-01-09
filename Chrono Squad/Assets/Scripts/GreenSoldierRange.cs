using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSoldierRange: MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "GhostPlayer")
        {
            //gameObject.GetComponent<Animator>().SetBool();
            //gameObject.setBool(inRange, true);
            gameObject.GetComponentInParent<GreenSoldierController>().PrepareThrow();

        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "GhostPlayer")
        {
            //gameObject.GetComponentInParent<GreenSoldierController>().Attack();
            gameObject.GetComponentInParent<GreenSoldierController>().PrepareThrow();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "GhostPlayer")
        {
            //gameObject.GetComponentInParent<GreenSoldierController>().Attack();
            gameObject.GetComponentInParent<GreenSoldierController>().OutOfRange();
        }

    }
}
