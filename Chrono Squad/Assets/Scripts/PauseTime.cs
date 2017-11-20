using UnityEngine;
using System.Collections;

public class PauseTime : MonoBehaviour {
    public bool paused;
    // Use this for initialization
    void Start () {
        paused = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Pause ();
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (Time.timeScale == 0)
            {
                gameObject.gameObject.GetComponent<Player1Controller>().reviveTrigger();
            }
            Time.timeScale = 1; 
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Time.timeScale = 0;
        }

        if (Time.timeScale == 0.1f && gameObject.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("player_dead"))
        {
            Time.timeScale = 0;
        }
    }

    public void Pause (){

        paused = !paused;
        if (paused) {

            Time.timeScale = 0;
        }

        else if(!paused) {

            Time.timeScale = 1;
        }
    }

    public void SlowDown(){
        Time.timeScale = 0.2f;
    }

    public void Rewind(){
        Time.timeScale = 1;
    }
}
