using UnityEngine;
using System.Collections;

public class PauseTime : MonoBehaviour {
    public bool paused;
    int rewindcounter;
    // Use this for initialization
    void Start () {
        paused = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            //Pause ();
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (rewindcounter == 10)
            {
                SpeedUp();
            }
            rewindcounter++;
            Normal();
            //Time.timeScale = 1; 
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            rewindcounter = 0;
            Pause();
        }

        if (Time.timeScale == 0.2f && gameObject.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("player_dead"))
        {
            Pause();
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

    public void Normal(){
        paused = false;
        Time.timeScale = 1;
    }

    public void SpeedUp(){
        //Time.timeScale = 2;
    }
}
