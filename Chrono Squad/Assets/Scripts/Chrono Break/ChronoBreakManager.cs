using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChronoBreakManager : MonoBehaviour
{
    public const int RECORDLENGTH = 300;
    public const float LEVEL_TIME = 10.0f;
    public Text text;
    private int frame = 0;
    private bool rewindState = false;
    private List<IChronoObject> objects = new List<IChronoObject>();

    public GameObject player; //player's prefab
    public Vector3 spawn;

    void Start()
    {
        spawn = player.transform.position;
    }

    //When the state changes, do the following
    void LateUpdate()
    {
        text.text = "FRAME: " + frame;

        //After 10 seconds change to rewind state
        if (!rewindState && Time.timeSinceLevelLoad >= LEVEL_TIME)
        {
            rewindState = true;
            Time.timeScale = -1.0f;
            foreach (var obj in objects)
            {
                obj.ChangeState();
            }
        }
        //After 10 seconds change back to record state
        //And spawn a new CONTROLLABLE player
        else if (rewindState && Time.timeSinceLevelLoad <= 0.0f)
        {
            rewindState = false;
            foreach (var obj in objects)
            {
                obj.ChangeState();
            }
            Instantiate(player, spawn, Quaternion.identity);

        }
    }

    public void Rewind()
    {
        //TODO allow rewinding give player action
    }

    public void registerObject(IChronoObject chronoBreakCharacter)
    {
        objects.Add(chronoBreakCharacter);
    }
}
