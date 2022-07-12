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
    [SerializeField] private WheelCollider left3Collider;
    [SerializeField] private WheelCollider left4Collider;
    [SerializeField] private WheelCollider left5Collider;
    [SerializeField] private WheelCollider right1Collider;
    [SerializeField] private WheelCollider right2Collider;
    [SerializeField] private WheelCollider right3Collider;
    [SerializeField] private WheelCollider right4Collider;
    [SerializeField] private WheelCollider right5Collider;
    
    [SerializeField] private Transform left1Transform;
    [SerializeField] private Transform left2Transform;
    [SerializeField] private Transform left3Transform;
    [SerializeField] private Transform left4Transform;
    [SerializeField] private Transform left5Transform;
    [SerializeField] private Transform right1Transform;
    [SerializeField] private Transform right2Transform;
    [SerializeField] private Transform right3Transform;
    [SerializeField] private Transform right4Transform;
    [SerializeField] private Transform right5Transform;

    public float speed;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteeringAngle;

    private void FixedUpdate()
    {
        if (enterOrExitScript.inCar)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical2");
            isBrakeing = Input.GetKey(KeyCode.LeftControl);
        }
        
        left2Collider.motorTorque = (verticalInput * speed);
        right2Collider.motorTorque = (verticalInput * speed);
        left1Collider.motorTorque = (verticalInput * speed);
        right1Collider.motorTorque = (verticalInput * speed);
        
        left3Collider.motorTorque = (verticalInput * speed/2);
        left4Collider.motorTorque = (verticalInput * speed/2);
        left5Collider.motorTorque = (verticalInput * speed/2);
        right3Collider.motorTorque = (verticalInput * speed/2);
        right4Collider.motorTorque = (verticalInput * speed/2);
        right5Collider.motorTorque = (verticalInput * speed/2);
        
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
        left3Collider.brakeTorque = currentBrakeForce;
        left4Collider.brakeTorque = currentBrakeForce;
        left5Collider.brakeTorque = currentBrakeForce;
        right1Collider.brakeTorque = currentBrakeForce;
        right2Collider.brakeTorque = currentBrakeForce;
        right3Collider.brakeTorque = currentBrakeForce;
        right4Collider.brakeTorque = currentBrakeForce;
        right5Collider.brakeTorque = currentBrakeForce;
        

        currentSteerAngle = maxSteeringAngle * horizontalInput;
        left1Collider.steerAngle = currentSteerAngle;
        right1Collider.steerAngle = currentSteerAngle;
       // left2Collider.steerAngle = currentSteerAngle;
        //right2Collider.steerAngle = currentSteerAngle;
        
        UpdateSingleWheel(left1Collider, left1Transform);
        UpdateSingleWheel(left2Collider, left2Transform);
        UpdateSingleWheel(left3Collider, left3Transform);
        UpdateSingleWheel(left4Collider, left4Transform);
        UpdateSingleWheel(left5Collider, left5Transform);
        UpdateSingleWheel(right1Collider, right1Transform);
        UpdateSingleWheel(right2Collider, right2Transform);
        UpdateSingleWheel(right3Collider, right3Transform);
        UpdateSingleWheel(right4Collider, right4Transform);
        UpdateSingleWheel(right5Collider, right5Transform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.rotation = rotation;
        wheelTransform.position = position;
    }
}
