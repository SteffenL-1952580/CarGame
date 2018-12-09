using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMaster : MonoBehaviour
{

    private static CheckpointMaster instance;
    public Vector3 lastCheckPointPos;
    public GameObject[] checkpoints;
    public int currentCheckpoint = 0;
    public GameObject nextCheckpoint;
    public String directionToCheck;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            directionToCheck = "straight";
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
