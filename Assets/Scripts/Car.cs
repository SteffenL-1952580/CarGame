using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Car : MonoBehaviour
{
    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float motorForce = 50;
    public CircularDrive steeringWheel;
    public float steeringSensitivity = 2f;
   
    public CircularDrive lever;
    public bool driveForward = false;
    public bool driveBackward = false;

    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        //steeringAngle = maxSteerAngle * horizontalInput;
        steeringAngle = steeringWheel.outAngle / steeringSensitivity;
        frontDriverW.steerAngle = steeringAngle;
        frontPassengerW.steerAngle = steeringAngle;

        Debug.Log(steeringWheel.outAngle);
    }

    private void Accelerate()
    {
        frontDriverW.motorTorque = verticalInput * motorForce * 10;
        frontPassengerW.motorTorque = verticalInput * motorForce * 10;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void AcceleratePedalPress()
    {
        if(driveForward && !driveBackward)
        {
            //frontDriverW.motorTorque = verticalInput * motorForce * 10;
            //frontPassengerW.motorTorque = verticalInput * motorForce * 10;
            
            //code to accelerate on pedal press. modify the code above to work similar but on pedal press.
        }
    }

    private void UpdateDriveStatus()
    {
        float leverAngle = lever.outAngle;
        if (leverAngle >= 10)
        {
            driveForward = true;
            driveBackward = false;
        } else if (10 > leverAngle && leverAngle > -10)
        {
            driveForward = false;
            driveBackward = false;
        }
        else
        {
            driveForward = false;
            driveBackward = true;
        }
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        UpdateDriveStatus();
    }
}
