using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointMaster cpm;

    void Start()
    {
        cpm = GameObject.FindGameObjectWithTag("CheckpointMaster").GetComponent<CheckpointMaster>();
        cpm.nextCheckpoint = cpm.checkpoints[0];
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if ((cpm.nextCheckpoint).transform.position == transform.position)
            {
                //cpm.lastCheckPointPos = transform.position;
                cpm.currentCheckpoint += 1;
                cpm.nextCheckpoint = cpm.checkpoints[cpm.currentCheckpoint];
                this.GetComponent<Renderer>().material.color = Color.green;
            }
            
        }
        



    }

}