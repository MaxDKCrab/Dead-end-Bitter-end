using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCamera : MonoBehaviour
{

    [Header("This script does not currently have a use, leave it turned off")]
    [Header("It might be repurposed to shoot cinematic sequences")]
    [Header("")]
    
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private float followSpeed = 0f;
    //[SerializeField] private float rotationSpeed;

    private Vector3 velocity = Vector3.one;
    
 
    void LateUpdate()
    {
        Vector3 targetPosition = objectToFollow.TransformPoint(offset);
        // Vector3 targetPosition = objectToFollow.position + (objectToFollow.rotation * offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity,followSpeed);

        transform.LookAt(objectToFollow, objectToFollow.up);
        
        // var direction = objectToFollow.position - transform.position;
        // var rotation = Quaternion.LookRotation(direction, Vector3.up);
        // transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
