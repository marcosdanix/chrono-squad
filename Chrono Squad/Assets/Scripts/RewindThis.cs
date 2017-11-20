using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class RewindThis : MonoBehaviour
{
    List<PointInTime> playerPosition;

    List<Vector3> positionVal = new List<Vector3>();

    List<PointInTime> rewindPositions = new List<PointInTime>();

    List<Vector3> rotationRewind = new List<Vector3>();
    List<Vector3> rotationVal = new List<Vector3>();
    int indexVal;
    float counter;
    bool isRewinding;
    int timeLimitInSeconds =10;
    private MainTimeController timeController;
    public PlayerAnimation playerAnim;
    public Player1Controller playerController;

    public GameObject ghostObject;

    void Start()
    {
        timeController = gameObject.GetComponent<MainTimeController>();
        playerAnim = gameObject.GetComponentInChildren<PlayerAnimation> ();
        playerController = gameObject.GetComponent<Player1Controller>();
        playerPosition = new List<PointInTime>();
    }
    void Update()
    {
        //we use a counter variable to limit the rewind mechanic usage to 10 seconds
        if(Input.GetKey(KeyCode.E))
        {
            //playerAnim.rewind = -1.0f;
            if (counter > 0) {
                counter -= Time.deltaTime;
                isRewinding = true;
                Rewind ();
            } 
            if (counter <= 0) {
                Rewind();
            }

        }
        else
        {

            if (Input.GetKeyUp(KeyCode.E))
            {
                //ghostObject = Instantiate(ghostObject,transform.position, Quaternion.identity);
                gameObject.GetComponent<GhostReplay>().Populate(rewindPositions);

                rewindPositions = new List<PointInTime>();
            }

            if(counter<timeLimitInSeconds)
            {
                counter+=Time.deltaTime;
            }
            //playerAnim.rewind = 1.0f;
            isRewinding = false;

        }
        //if time is moving forward, keep adding new elements to the arrays
        if (!isRewinding) {
            if (Time.timeScale == 0) {
                return;
            }
            playerPosition.Insert(0, new PointInTime(transform.position,transform.localScale,true));
//            positionVal.Add (transform.position);
//            rotationVal.Add (transform.localScale);
//
            //timeController.addPlayerMovement(gameObject,positionVal);

            //increase the index every frame
            indexVal++;

        }
    }
    //method that actually 'rewinds' the game
    void Rewind()
    {

        //if current index is not 0
        if (indexVal > 0)
        {
            //decrease index

            //get last data of this gameobject and apply it to the gameobject
            //remove the used data thereby decreasing the list size

            PointInTime pointInTime = playerPosition[0];
            rewindPositions.Insert(0, pointInTime);
            transform.position = pointInTime.position;
            transform.localScale = pointInTime.rotation;
            playerPosition.RemoveAt(0);
//            rewindVal.Add(positionVal[indexVal - 1]);
//            transform.position = positionVal[indexVal - 1];
//            positionVal.RemoveAt(indexVal - 1);
//            rotationRewind.Add(rotationVal[indexVal - 1]);
//            transform.localScale = rotationVal[indexVal - 1];
//            rotationVal.RemoveAt(indexVal - 1);
        }
        else
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            rewindPositions.Insert(0, new PointInTime(Vector3.zero, Vector3.zero, true));
            //rewind.Add(Vector3.zero);
            //rotationVal.Add(Vector3.zero);
        }
        indexVal--;

    }
}

