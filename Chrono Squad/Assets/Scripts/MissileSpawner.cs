using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{

    public GameObject MainCamera;
    public GameObject Prefab;
    int counter;
    bool rewindCheck = false;
    public bool spawnEnabled = true;

    // Use this for initialization
    void Start()
    {
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
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
            if (counter == 300) //Spawn every 300 frames = 5 seconds
            {
                Vector3 position = new Vector3(Random.Range(MainCamera.transform.position.x - 16, MainCamera.transform.position.x + 16), 22, 0); //Spawn inside the current camera area
                Instantiate(Prefab, position, Quaternion.identity);
                counter = 0;
            }
        }
        
    }
}
