using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CollideScript : MonoBehaviour {


    public Text collideText;

    public ParticleSystem smoke;

	// Use this for initialization
	void Start () {
        collideText.text = string.Empty;
	}
	
	// Update is called once per frame
	void Update () {
        
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "TestCarObject" || collision.gameObject.tag=="Obstacle")
        {
            //Show on dashboard
            SetCollideText();

            //Show Smoke
            smoke.Play();

            //reload scene

            Invoke("Reload", 5.0f);
        }


        if (collision.gameObject.tag == "Sensor")
        {
            collideText.text = "Red light passed";
        }

    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void SetCollideText()
    {
        collideText.text = "You crashed, start again!";
    }
}
