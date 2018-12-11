using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public GameObject[] bodies;
    public Material[] materials;
    private Renderer rend;

	void Start ()
	{
	    //rend = gameObject.GetComponent<Renderer>();
	    //rend.material.color = materials[2].color;
	   
        bodies[2].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
