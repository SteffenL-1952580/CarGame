using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoostScript : MonoBehaviour {

    private GameObject car;
    private Car carScript;
    public Text boostText;
    // Use this for initialization
    void Start () {

        car = GameObject.FindGameObjectWithTag("Player");
        carScript = car.GetComponent<Car>();
        boostText.text = "";
        boostText.enabled = true;
    }
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            carScript.isBoosting = true;
            boostText.text = "BOOSTING ENABLED";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Invoke("DisableBoosting", 3f);
    }


    private void DisableBoosting()
    {
        carScript.isBoosting = false;
        boostText.text = "";
    }
}
