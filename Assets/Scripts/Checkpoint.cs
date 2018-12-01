using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Checkpoint : MonoBehaviour
{
    private CheckpointMaster cpm;

    private GameObject car;
    private CountDownScript script;


    void Start()
    {
        //for timer
        car = GameObject.Find("Car");
        script = car.GetComponent<CountDownScript>();


        cpm = GameObject.FindGameObjectWithTag("CheckpointMaster").GetComponent<CheckpointMaster>();

        foreach (GameObject checkpoint in cpm.checkpoints)
        {
            checkpoint.GetComponent<Renderer>().material.color = Color.clear;

        }

        cpm.nextCheckpoint = cpm.checkpoints[0];
        cpm.nextCheckpoint.GetComponent<Renderer>().material.color = Color.green;
    }

    private void Update()
    {
        //code needs to execute after entering last checkpoint && reset timer after second round
        if (Input.GetKeyDown("space"))
        {
            script.PassedLastCheckPoint = true;
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if ((cpm.nextCheckpoint).transform.position == transform.position)
            {
                cpm.checkpoints[cpm.currentCheckpoint].GetComponent<Renderer>().material.color = Color.clear;

                if (cpm.currentCheckpoint+1 == cpm.checkpoints.Length)
                {
                    cpm.currentCheckpoint = 0;
                    cpm.nextCheckpoint = cpm.checkpoints[0];

                   // script.PassedLastCheckPoint = true;
                 
                }
                else
                {
                    cpm.currentCheckpoint += 1;
                    cpm.nextCheckpoint = cpm.checkpoints[cpm.currentCheckpoint];
                }

                cpm.nextCheckpoint.GetComponent<Renderer>().material.color = Color.green;
            }

        }
        



    }

}