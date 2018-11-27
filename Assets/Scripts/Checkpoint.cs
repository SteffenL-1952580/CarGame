using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointMaster cpm;

    void Start()
    {
        cpm = GameObject.FindGameObjectWithTag("CheckpointMaster").GetComponent<CheckpointMaster>();

        foreach (GameObject checkpoint in cpm.checkpoints)
        {
            checkpoint.GetComponent<Renderer>().material.color = Color.clear;

        }

        cpm.nextCheckpoint = cpm.checkpoints[0];
        cpm.nextCheckpoint.GetComponent<Renderer>().material.color = Color.green;
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