using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{

    public GameObject MainCamera;
    public GameObject Prefab;
    public int counter;
    public bool rewindCheck;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
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


        if (!rewindCheck)
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
