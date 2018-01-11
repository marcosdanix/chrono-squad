using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public Image ProgressMarker;
    public RectTransform rectTransform;
    int counter = 0;
    bool rewindCheck = false;

    // Use this for initialization
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            rewindCheck = true;
            Rewind();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            rewindCheck = false;
        }


        if (!rewindCheck)
            {
                Move();
            }
        
    }

    public void Move()
    {
        if(counter < 600)
        {
            rectTransform.localPosition += Vector3.right * 950 / 600;
            counter++;
        }
    }

    public void Rewind()
    {
        if (counter > 0)
        {
            rectTransform.localPosition += Vector3.left * 950 / 600;
            counter--;
        }
    }
}
