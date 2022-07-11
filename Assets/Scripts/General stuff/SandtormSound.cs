using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandtormSound : MonoBehaviour
{

    private Transform playerTrans;
    private float distanceToStorm;
    
    
    void Start()
    {
        playerTrans = FindObjectOfType<Movement>().gameObject.transform;
    }

    
    void Update()
    {

        distanceToStorm = Vector3.Distance(playerTrans.position, transform.position);
        distanceToStorm = Math.Clamp(distanceToStorm, 0, 300);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("DistensWind", distanceToStorm);


    }
}
