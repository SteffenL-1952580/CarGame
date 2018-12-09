using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightScript : MonoBehaviour {

    public GameObject RedLight;
    public GameObject OrangeLight;
    public GameObject GreenLight;
    public Material orangeMaterial;

    private bool isBusy = false;

	// Use this for initialization
	void Start () {

        RedLight.GetComponent<Renderer>().material.color = Color.black;
        OrangeLight.GetComponent<Renderer>().material.color = Color.black;
        GreenLight.GetComponent<Renderer>().material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {

        if (isBusy == false)
        {
            StartCoroutine(TrafficLigh());
        }
  	}
    
    IEnumerator TrafficLigh()
    {
        isBusy = true;

        SetGreen();
        yield return new WaitForSeconds(2F);

        SetOrange();
        yield return new WaitForSeconds(3f);      
         
        SetRed();
        yield return new WaitForSeconds(10f);
           
        isBusy = false;

    }    
    


    void SetRed()
    {
        RedLight.GetComponent<Renderer>().material.color = Color.red;
        OrangeLight.GetComponent<Renderer>().material.color = Color.black;
        GreenLight.GetComponent<Renderer>().material.color = Color.black;
        

    }
    void SetGreen()
    {
        RedLight.GetComponent<Renderer>().material.color = Color.black;
        OrangeLight.GetComponent<Renderer>().material.color = Color.black;
        GreenLight.GetComponent<Renderer>().material.color = Color.green;
       
    }

    void SetOrange()
    {
        RedLight.GetComponent<Renderer>().material.color = Color.black;
        OrangeLight.GetComponent<Renderer>().material = orangeMaterial;
        GreenLight.GetComponent<Renderer>().material.color = Color.black;

    }


}
