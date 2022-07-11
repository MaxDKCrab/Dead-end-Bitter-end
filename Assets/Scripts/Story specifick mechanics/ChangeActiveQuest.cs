using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActiveQuest : MonoBehaviour
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
            questWayPoint.activeQuestArrayValue++;
            Destroy(this);
        }
    }
    
    public void IncramentActiveQuestExternal()
    {
        questWayPoint.activeQuestArrayValue++;
    }
}

