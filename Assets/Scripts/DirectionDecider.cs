using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class DirectionDecider : MonoBehaviour
{

    private CheckpointMaster cpm;
    private float previousPos;
    private float currentPos;
    private int currentCheckpoint;
    private int interval = 4;
    private float nextTime = 0;
    //private GameObject GameObject;

    void Start()
    {
        cpm = GameObject.FindGameObjectWithTag("CheckpointMaster").GetComponent<CheckpointMaster>();
        currentCheckpoint = cpm.currentCheckpoint;
        previousPos = cpm.checkpoints[currentCheckpoint].transform.position.z - gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = cpm.checkpoints[cpm.currentCheckpoint].transform.position.z - gameObject.transform.position.z;

        if (Time.time >= nextTime)
        {
            if (currentCheckpoint == cpm.currentCheckpoint)
            {
                if (currentPos <= previousPos + 1)
                {
                    Debug.Log("Right way! Pos:" + currentPos + " Prev pos:" + (previousPos));
                }
                else
                {
                    Debug.Log("wrong way! Pos:" + currentPos + " Prev pos:" + (previousPos));
                }
                previousPos = currentPos;
                nextTime += interval;
            }
            else
            {
                currentCheckpoint = cpm.currentCheckpoint;
                previousPos = currentPos;
            }
            

        }
        // Debug.Log(cpm.checkpoints[cpm.currentCheckpoint].transform.position.z - car.transform.position.z);

    }
}
