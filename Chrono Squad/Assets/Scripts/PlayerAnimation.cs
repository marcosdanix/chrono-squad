using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    Animator anim;
    public GameObject player;
    Vector2 current_dir;
    int rotation;
    public float rewind=1.0f;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator> ();
//        int jumpHash = Animator.StringToHash("Jump");
//        anim.speed = -1;
//        anim.time = anim.l
//        anim.Play("bridge");
	}
	
	// Update is called once per frame
	void Update () {

        current_dir = Vector2.zero;
        Player1Controller playerScript = player.GetComponent<Player1Controller> ();

        anim.SetBool("Grounded", playerScript.grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        anim.SetFloat("rewind", rewind);

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            current_dir += Vector2.left;
        }
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            current_dir += Vector2.right;
        }

        if (Input.GetAxis("Vertical") < -0.1f)
        {
            //transform.localScale = new Vector3(1, -1, 1);
            current_dir += Vector2.down;
        }
        if (Input.GetAxis("Vertical") > 0.1)
        {
            //transform.localScale = new Vector3(1, 1, 1);
            current_dir += Vector2.up;
        }

        if (current_dir == Vector2.zero)
        {
            current_dir = new Vector2(transform.localScale.x,0);
        }

        rotation = (int) Vector2.Angle(Vector2.right, current_dir);
        Vector3 cross = Vector3.Cross(transform.localScale, current_dir);
        if (cross.x > 0)
        {
            rotation = -rotation;
        }


        if (rotation == 135)
        {
            rotation = 45;
        }
        else if (rotation == 90 || rotation == -90)
        {
        }
        else if (rotation == 180){
            rotation = 0;
        }

        anim.SetInteger("Rotation", rotation);

	}
    public void AnimationEvent(){
        gameObject.GetComponentInParent<PauseTime>().Pause();
    }
}
