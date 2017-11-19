using UnityEngine;
using System.Collections;

public class ChronoBreakCharacter : MonoBehaviour, IChronoObject
{
    //State
    //What's a state pattern lol?
    private bool isRecordState;
    private bool isRewindState;

    private CharacterState[] stateRecord;
    private Rigidbody2D rb;
    private int frameCount; //count up while recording, or playing back
                            //use as total during rewind

    private float LEVEL_TIME = ChronoBreakManager.LEVEL_TIME;

    //initial state is record
    void Awake()
    {
        this.isRecordState = true;
        this.isRewindState = false;
        this.stateRecord = new CharacterState[ChronoBreakManager.RECORDLENGTH];
        this.rb = GetComponent<Rigidbody2D>();
        this.frameCount = 0;
    }

    //Tell ChronoBreakManager I was created (and it knows about me)
    void Start()
    {
        var manager = GameObject.Find("Chrono Break Manager");
        //manager.GetComponent<ChronoBreakManager>().recordEvent(new CreatedEvent(this));
        manager.GetComponent<ChronoBreakManager>().registerObject(this);

    }

    //Save state
    void Update()
    {
        if (this.isRecordState)
        {
            stateRecord[frameCount++] = new CharacterState(this.transform);
        }
        else if (this.isRewindState)
        {
            //This is necessary beacause the manager rewinds based on passed time
            //instead of the # of frames
                            //this is going at -1.0 member? or any possible speed.
            int frame = (int)(Time.realtimeSinceStartup / ((float)frameCount));
            stateRecord[frame].loadState(this.transform);
        }
        else //replay state
        {
            stateRecord[frameCount++].loadState(this.transform);
        }
    }

    //This method is called by the manager
    public void ChangeState() //what is a FSM?
    {
        if (isRecordState)
        {
            this.isRecordState = false;
            this.isRewindState = true;
            
            //Stuff you turn off
            this.rb.simulated = false;
        }
        else
        {
            this.isRewindState = !this.isRewindState; //State pattern is overrated
            if (!this.isRewindState) frameCount = 0;
        }
    }
}
