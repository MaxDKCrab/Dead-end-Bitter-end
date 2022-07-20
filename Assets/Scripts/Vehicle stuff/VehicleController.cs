using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField] private EnterOrExitVehicle enterOrExitScript;
    
    private float horizontalInput;
    private float verticalInput;
    private bool isBrakeing;
    private float currentBrakeForce;
    private float currentSteerAngle;
    
    //Den här siffran kommer vi ge ett värde längre ner
    public float currentMotorTorque;
    
    [SerializeField] private WheelCollider left1Collider;
    [SerializeField] private WheelCollider left2Collider;
    [SerializeField] private WheelCollider right1Collider;
    [SerializeField] private WheelCollider right2Collider;

    public float speed;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteeringAngle;

    private void FixedUpdate()
    {
        if (enterOrExitScript.inCar)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            isBrakeing = Input.GetKey(KeyCode.LeftControl);
        }
        
        left2Collider.motorTorque = (verticalInput * speed);
        right2Collider.motorTorque = (verticalInput * speed);
        left1Collider.motorTorque = (verticalInput * speed);
        right1Collider.motorTorque = (verticalInput * speed);
        
     
        
        //currentMotorTorque den här siffran kan vi använda som en parameter för motorljud osv
        currentMotorTorque = (left2Collider.motorTorque + right2Collider.motorTorque) / 2f;
        // FMODUnity.RuntimeManager.StudioSystem.setParameterByName("RPM", -currentMotorTorque);

        
        if (!enterOrExitScript.inCar)
        {
            currentBrakeForce = brakeForce;
        }
        else
        {
            currentBrakeForce = isBrakeing ? brakeForce : 0f;
        }
        
        left1Collider.brakeTorque = currentBrakeForce;
        left2Collider.brakeTorque = currentBrakeForce;
        
        right1Collider.brakeTorque = currentBrakeForce;
        right2Collider.brakeTorque = currentBrakeForce;
      
        

        currentSteerAngle = maxSteeringAngle * horizontalInput;
        left1Collider.steerAngle = currentSteerAngle;
        right1Collider.steerAngle = currentSteerAngle;
        }
    }
