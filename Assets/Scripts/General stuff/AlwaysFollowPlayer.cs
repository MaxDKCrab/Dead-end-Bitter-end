using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform vehiclePos;
    [SerializeField] private float mapLowestPoint;
    private float playerElevation;
    private EnterOrExitVehicle enterExitVehicleScript;
    public float elevationParameter;
    // Start is called before the first frame update
    void Start()
    {

        enterExitVehicleScript = vehiclePos.GetComponent<EnterOrExitVehicle>();
    }

    void Update()
    {
        
       
        playerElevation = transform.position.y;
        elevationParameter = playerElevation - mapLowestPoint;
        
        if (enterExitVehicleScript.inCar)
        {
            transform.position = vehiclePos.position;
        }
        else
        {
            transform.position = playerPos.position;
        }
        
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("YX", elevationParameter);
        


       
    }
}
