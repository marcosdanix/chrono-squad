using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFightManager : MonoBehaviour {

    public GameObject player;
    public GameObject boss;
    public GameObject mainCamera;
    Collider2D checkpoint;
    Collider2D playerCollider;


    bool playerInPosition = false;
    bool bossFightStarted = false;
    public bool bossDead = false;
    bool reachedBossFightPosition = false;
    float bossFightInitialPosition = 388; //boss position
    int endLevelCounter = 0;

    // Use this for initialization
    void Start () {
        checkpoint = GetComponentInChildren<Collider2D>();
        playerCollider = player.GetComponent<Collider2D>();
        //missileSpawner = missileSpawner;
}

    // Update is called once per frame
    private void Update()
    {
        
    }

    void FixedUpdate () {

        if (checkpoint.IsTouching(playerCollider) && !bossFightStarted)
        {
            bossFightStarted = true;
            BossFightStart();
        }

        if ((player.transform.position.x >= bossFightInitialPosition - 5) && !reachedBossFightPosition)
        {
            reachedBossFightPosition = true;
            mainCamera.transform.position = new Vector3(bossFightInitialPosition, mainCamera.transform.position.y, mainCamera.transform.position.z);
            mainCamera.GetComponent<CamaraFollow>().bossFightInPosition = true; //stop following the player 
            boss.GetComponent<BossController>().startCounters = true; //start timers for boss attacks
            player.GetComponent<Player1Controller>().bossFightStarted = true;
        }
        if (bossDead)
        {
            endLevelCounter++;
            if(endLevelCounter > 300) //5 seconds after boss death
            {
                LevelEnd();
            }
            
        }
    }



    void BossFightStart() //necessary preparations for boss fight
    {
        mainCamera.GetComponent<MissileSpawner>().spawnEnabled = false; //turn off missile spawn
        mainCamera.GetComponent<GreenSoldierSpawner>().spawnEnabled = false; //turn off soldier spawn
    }

    void LevelEnd()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
