using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightManager : MonoBehaviour {

    public GameObject player;
    public GameObject boss;
    public GameObject mainCamera;
    Collider2D checkpoint;
    Collider2D playerCollider;


    bool playerInPosition = false;
    bool bossFightStarted = false;
    bool bossDead = false;
    float bossFightInitialPosition = 388; //boss position

    // Use this for initialization
    void Start () {
        checkpoint = GetComponentInChildren<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();
        //missileSpawner = missileSpawner;
}
	
	// Update is called once per frame
	void Update () {

        if (checkpoint.IsTouching(playerCollider) && !bossFightStarted)
        {
            bossFightStarted = true;
            BossFightStart();
        }

        if (player.transform.position.x >= bossFightInitialPosition)
        {
            mainCamera.transform.position = new Vector3(bossFightInitialPosition, mainCamera.transform.position.y, mainCamera.transform.position.z);
            mainCamera.GetComponent<CamaraFollow>().bossFightInPosition = true; //stop following the player 
            boss.GetComponent<BossController>().startCounters = true; //start timers for boss attacks
            player.GetComponent<Player1Controller>().bossFightStarted = true;
        }
        if (bossDead)
        {
            LevelEnd();
        }
    }



    void BossFightStart() //necessary preparations for boss fight
    {
        mainCamera.GetComponent<MissileSpawner>().spawnEnabled = false; //turn off missile spawn
        mainCamera.GetComponent<GreenSoldierSpawner>().spawnEnabled = false; //turn off soldier spawn
    }

    void LevelEnd()
    {

    }
}
