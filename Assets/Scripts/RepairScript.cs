using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairScript : MonoBehaviour
{
    private GameObject car;
    private CollideScript collideScript;
    // Use this for initialization
    void Start()
    {
        // smoke.Play();   
        car = GameObject.Find("Car");
        collideScript = car.GetComponent<CollideScript>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (collideScript.smoke.isPlaying)// || collideScript.crashCount == 1)
        {
            collideScript.smoke.Stop();
            //collideScript.collideText.text = "smoke stopped";
            collideScript.crashCount = 0;
        }
        
    }
}
