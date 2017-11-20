using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReplay : MonoBehaviour {

//    List<Vector3> positionList = new List<Vector3>();
//    List<Vector3> rotationList = new List<Vector3>();

    List<PointInTime> ghostPosition = new List<PointInTime>();
    int maxIndexVal = 0;
    int currentIndex = 0;
	// Use this for initialization
	void Start () {
		
	}

    public void Populate(List<PointInTime> positionVal)
    {
        ghostPosition = positionVal;
        maxIndexVal = positionVal.Count;
        currentIndex = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0) {
            return;
        }
        if (maxIndexVal > currentIndex)
        {
            //decrease index

            //get last data of this gameobject and apply it to the gameobject
            //remove the used data thereby decreasing the list size
            if (ghostPosition[currentIndex].position != Vector3.zero && !gameObject.GetComponentInChildren<SpriteRenderer>().enabled)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
            transform.position = ghostPosition[currentIndex].position;
            transform.localScale = ghostPosition[currentIndex].rotation;

            //transform.eulerAngles = rotationVal[indexVal];
            currentIndex++;
        }

	}
}
