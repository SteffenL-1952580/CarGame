using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorCollisionScript : MonoBehaviour {

    public Text collideText;
    public GameObject RedLight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

 
    void OnTriggerEnter(Collider other)
    {
        if(RedLight.GetComponent<Renderer>().material.color == Color.red)
        {
            collideText.text = "Stop for a Red Light!";
        }
     
    }

  

}
