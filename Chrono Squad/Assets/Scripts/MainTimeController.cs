using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTimeController : MonoBehaviour {

    Dictionary<GameObject,List<Vector3>> positionDic = new Dictionary<GameObject,List<Vector3>>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addPlayerMovement(GameObject game_object,List<Vector3> player_movement)
    {
        positionDic.Add(game_object, player_movement);
        GameObject gObj = (GameObject)Instantiate(game_object);
    }

    public void RewindAll()
    {
        
    }

    public void PlayAll()
    {
        //foreach(var obj in positionDic.Keys)
        //{
          //  GameObject gObj = (GameObject)Instantiate(obj);

        //}   
    }
}
