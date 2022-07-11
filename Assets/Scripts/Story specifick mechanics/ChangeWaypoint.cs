using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWaypoint : MonoBehaviour
{
    private bool isInObjectRange;
    public float pickUpRange;
    public LayerMask playerLayer;
    
    public QuestWaypoint questWayPoint;
    void Update()
    {
        isInObjectRange = Physics.CheckSphere(transform.position, pickUpRange, playerLayer);

        if (isInObjectRange && Input.GetKeyDown(KeyCode.E))
        {
            questWayPoint.targetArrayValue++;
            Destroy(this);
        }
        
    }

    public void IncramentWaypointExternal()
    {
        questWayPoint.targetArrayValue++;
    }
}
