using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMassChanger : MonoBehaviour
{

    public Vector3 centerOfMass2;
    public bool isAwake;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rb.centerOfMass = centerOfMass2;
        rb.WakeUp();
        isAwake = !rb.IsSleeping();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * centerOfMass2, 1f);
    }
}
