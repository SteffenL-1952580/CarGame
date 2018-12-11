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
    public float steeringSensitivity = 10f;
    public CircularDrive lever;
    public bool canControl = false;
    public bool isBoosting = false;
    public float boostPower = 5f;

    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;


    //private void GetInput()
    //{
    //    horizontalInput = Input.GetAxis("Horizontal");
    //    verticalInput = Input.GetAxis("Vertical");
    //}

    private void Steer()
    {
        //steeringAngle = maxSteerAngle * horizontalInput;
        steeringAngle = (steeringWheel.outAngle / steeringSensitivity) * -1 ;
        frontDriverW.steerAngle = steeringAngle;
        frontPassengerW.steerAngle = steeringAngle;


    }

    //private void Accelerate()
    //{
    //    frontDriverW.motorTorque = verticalInput * motorForce * 10;
    //    frontPassengerW.motorTorque = verticalInput * motorForce * 10;
    //}

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

    private void Accelerate()
    {

      
        if (10 < lever.outAngle || lever.outAngle < -10)
        {
            if (isBoosting == false)
            {
                if(lever.outAngle < -10) {
                    frontDriverW.brakeTorque = 500;
                    frontPassengerW.brakeTorque = 500;
                }
                else
                {
                    frontDriverW.brakeTorque = 0;
                    frontPassengerW.brakeTorque = 0;
                }


                //Debug.Log(motorForce);
                frontDriverW.motorTorque = lever.outAngle * motorForce * 3;
                frontPassengerW.motorTorque = lever.outAngle * motorForce * 3;
            }else
            {
                Debug.Log("boosting");
                frontDriverW.motorTorque = (lever.outAngle * motorForce * 3) * boostPower;
                frontPassengerW.motorTorque = (lever.outAngle * motorForce * 3) * boostPower;
            }
        }
        else
        {
            frontDriverW.motorTorque = 0;
            frontPassengerW.motorTorque = 0;
        }
    }

    private void FixedUpdate()
    {
        if (canControl)
        {
            //GetInput();
            Steer();
            Accelerate();
            UpdateWheelPoses();
        }
    }
}
