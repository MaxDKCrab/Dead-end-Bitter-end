using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTriggerCollider : MonoBehaviour
{
    private GameProgressionManager gameProgress;
    private Collider thisColl;
    [SerializeField] private int CheckPointNum;

    private void Start()
    {
        thisColl = GetComponent<Collider>();
        gameProgress = FindObjectOfType<GameProgressionManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameProgress.currentCheckpoint = CheckPointNum;
        //maybe add visual indication that the checkpoint is reached
        thisColl.enabled = false;
    }
}
