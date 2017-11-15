using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReplay : MonoBehaviour {

    List<Vector3> positionList = new List<Vector3>();
    List<Vector3> rotationList = new List<Vector3>();
    int maxIndexVal = 0;

	// Use this for initialization
	void Start () {
		
	}

    public void Populate(List<Vector3> positionVal, List<Vector3> rotationVal)
    {
        positionList = positionVal;
        rotationList = rotationVal;
        maxIndexVal = positionVal.Count;
    }
	
	// Update is called once per frame
	void Update () {
        if (maxIndexVal>0)
        {
            //decrease index

            //get last data of this gameobject and apply it to the gameobject
            //remove the used data thereby decreasing the list size
            if (positionList[maxIndexVal - 1] != Vector3.zero && !gameObject.GetComponentInChildren<SpriteRenderer>().enabled)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
            transform.position = positionList[maxIndexVal - 1];
//            transform.localScale = rotationList[maxIndexVal - 1];

            //transform.eulerAngles = rotationVal[indexVal];
            maxIndexVal--;
        }

	}
}
