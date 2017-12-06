﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{

    public GameObject MainCamera;
    public GameObject Prefab;
    public int counter;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter == 8)
        {
            Vector3 position = new Vector3(Random.Range(-MainCamera.transform.position.x, MainCamera.transform.position.x), 8, 0);
            Instantiate(Prefab, position, Quaternion.identity);
            counter = 0;
        }
    }
}
