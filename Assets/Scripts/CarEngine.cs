using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour {

    public Transform path;
    public float maxSteerAngle = 45f;
    public WheelCollider wheelFl,wheelFr;
    public WheelCollider wheelRl, wheelRr;
    public float maxMotorTorque = 80f;
    public float maxBrakeTorque = 150f;
    public float currentSpeed;
    public float maxSpeed;
    public bool isBraking = false;

    private List<Transform> nodes;
    private int currentNode = 0;

	// Use this for initialization
	void Start () {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();

        nodes = new List<Transform>();


        for (int i = 0; i < pathTransforms.Length; i++)
        {

            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    private void FixedUpdate()
    {
        ApplySteer();
        Drive();
        CheckWayPointDistance();
        Braking();
    }

    
    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFl.steerAngle = newSteer;
        wheelFr.steerAngle = newSteer;

    }

    
    private void Drive()
    {

        currentSpeed = 2 * Mathf.PI * wheelFl.radius * wheelFl.rpm * 60 / 1000;
        
        if(currentSpeed < maxSpeed && !isBraking)
        {
            wheelFl.motorTorque = maxMotorTorque;
            wheelFr.motorTorque = maxMotorTorque;
           
        }else
        {
           
            wheelFl.motorTorque = 0;
            wheelFr.motorTorque = 0;
            //isBraking = true;
        }


     
    }

    private void CheckWayPointDistance()
    {
        if(Vector3.Distance(transform.position, nodes[currentNode].position ) < 1f)
        {
          
            if(currentNode == nodes.Count -1){
                currentNode = 0;

            }else
            {
                currentNode++;
            }
        }


        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 5f)
        {
            isBraking = true;
        }
        else
        {
            isBraking = false;
        }
    }

    private void Braking()
    {
        if (isBraking)
        {
            wheelRl.brakeTorque = maxBrakeTorque;
            wheelRr.brakeTorque = maxBrakeTorque;
        }

        wheelRl.brakeTorque = 0;
        wheelRr.brakeTorque = 0;
    }
}
