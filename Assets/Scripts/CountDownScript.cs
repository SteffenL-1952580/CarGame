using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System;

public class CountDownScript : MonoBehaviour {

    private float timeLeft = 3.0f;

    public Text countDownText;
    public Text timerText;
    public Text currentLapText;

    public bool PassedLastCheckPoint = false;


    private Stopwatch stopwatch;
    private Stopwatch roundwatch;
    private GameObject car;
    private Car carScript;
    private Checkpoint checkPointScript;

    private GameObject checkpoint;
    
    private int currentRound;
    private int maxRound = 3;
     
    private int hours;
    private int minutes;
    private int seconds;
    private int milliseconds;

    private bool isExecuted = false;

    // Use this for initialization
    void Start () {
        car = GameObject.Find("Car");
        carScript = car.GetComponent<Car>();

        stopwatch = new Stopwatch();
        roundwatch = new Stopwatch();
        currentRound = 0;
              
    }
	
	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;
      
        if (timeLeft < 0 && isExecuted == false)
        {
            countDownText.fontStyle = FontStyle.Bold;
            countDownText.text = "Go!";
            carScript.canControl = true;

            isExecuted = true;
            stopwatch.Start();
            roundwatch.Start();

            Invoke("DisableCountDownText", 2f);
        }
        else if(timeLeft > 0)
        {
            countDownText.text = Mathf.Round(timeLeft).ToString();
          
        }


        if (PassedLastCheckPoint == true)
        {
            currentRound++;
            TimeSpan ts = roundwatch.Elapsed;
            TimeSpan tsStopWatch = stopwatch.Elapsed;
            hours = ts.Hours;
            minutes = ts.Minutes;
            seconds = ts.Seconds;
            milliseconds = ts.Milliseconds;
            PassedLastCheckPoint = false;

            currentLapText.text = string.Format("Lap {0}: {1:00}:{2:00}:{3:00}.{4:00}", currentRound, hours, minutes, seconds, milliseconds);

            if (currentRound >= maxRound)
            {
                stopwatch.Stop();
                roundwatch.Stop();
                carScript.canControl = false;
                countDownText.enabled = true;

                TimeSpan ts2 = stopwatch.Elapsed;
                hours = tsStopWatch.Hours;
                minutes = tsStopWatch.Minutes;
                seconds = tsStopWatch.Seconds;
                milliseconds = tsStopWatch.Milliseconds;

                countDownText.text = string.Format("Your time: {0:00}:{1:00}:{2:00}.{3:00}", hours, minutes, seconds, milliseconds);

            }
            else
            {
                roundwatch.Reset();
                roundwatch.Start();
            }

        }
        else
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
