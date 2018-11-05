using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;


public class PostProcessingManager : MonoBehaviour
{
    private PostProcessingBehaviour DrunkProfile;

	// Use this for initialization
	void Start ()
	{
	    DrunkProfile = gameObject.GetComponent<PostProcessingBehaviour>();
	    DrunkProfile.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.D))
	    {
            toggleDrunkMode();
	    }
	}

    public void toggleDrunkMode()
    {
        DrunkProfile.enabled = !DrunkProfile.enabled;
    }
}
