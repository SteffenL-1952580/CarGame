using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System;

public class CountDownScript : MonoBehaviour {

    float timeLeft = 3.0f;

    public Text countDownText;
    public Text timerText;

    public bool PassedLastCheckPoint = false;

    private Stopwatch stopwatch;


    private GameObject car;
    private Car carScript;
    private Checkpoint checkPointScript;

    private GameObject checkpoint;

	// Use this for initialization
	void Start () {
        car = GameObject.Find("Car");
        carScript = car.GetComponent<Car>();

        stopwatch = new Stopwatch();


       // checkpoint = GameObject.Find("Checkpoint1");
        //checkPointScript = checkpoint.GetComponent<Checkpoint>();

	}
	
	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;
        countDownText.text = Mathf.Round(timeLeft).ToString();
        if(timeLeft < 0)
        {
            countDownText.fontStyle = FontStyle.Bold;
            countDownText.text = "go!";
            carScript.canControl = true;

            stopwatch.Start();
            Invoke("DisableCountDownText", 2f);
        }

       

        if (PassedLastCheckPoint == true)
        {
            stopwatch.Stop();
            
            // timerText.text = ts.ToString();

        }else
        {
            TimeSpan ts = stopwatch.Elapsed;
            timerText.text = ts.ToString();
        }
                

     }

    private void DisableCountDownText()
    {
        countDownText.enabled = false;
    }
}
