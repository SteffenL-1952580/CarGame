using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScript : MonoBehaviour {

    private GameObject car;
    private Car carScript;
	// Use this for initialization
	void Start () {

        car = GameObject.Find("Car");
        carScript = car.GetComponent<Car>();
    }
	

    private void OnTriggerEnter(Collider other)
    {
        carScript.isBoosting = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Invoke("DisableBoosting", 3f);
    }


    private void DisableBoosting()
    {
        carScript.isBoosting = false;
    }
}
