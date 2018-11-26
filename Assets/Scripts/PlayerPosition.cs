using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {

    private CheckpointMaster cpm;

    void Start()
    {
        cpm = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CheckpointMaster>();
        transform.position = cpm.lastCheckPointPos;
    }
}
