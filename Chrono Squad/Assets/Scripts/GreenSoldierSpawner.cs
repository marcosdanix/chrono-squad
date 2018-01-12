using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSoldierSpawner : MonoBehaviour
{

    public GameObject MainCamera;
    public GameObject Prefab;
    int counter;
    bool rewindCheck = false;
    public bool spawnEnabled = true;
    int randomNumber;
    Vector3[] positions = new Vector3[2] { Vector3.zero, Vector3.zero };
    Vector3 position;
    

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void FixedUpdate()
    {

        //Check if rewind is activated to stop spawning missiles
        if (Input.GetKey(KeyCode.E))
        {
            rewindCheck = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            rewindCheck = false;
        }


        if (!rewindCheck && spawnEnabled)
        {
            counter++;
            if (counter == 240) //Spawn every 300 frames = 4 seconds
            {
                positions[0] = new Vector3((MainCamera.transform.position.x - 30), -9, 0); //Spawn outside the current camera area
                positions[1] = new Vector3((MainCamera.transform.position.x + 30), -9, 0);
                randomNumber = Random.Range(0, 2);
                position = positions[randomNumber];
                Instantiate(Prefab, position, Quaternion.identity);
                counter = 0;
            }
        }

    }
}
