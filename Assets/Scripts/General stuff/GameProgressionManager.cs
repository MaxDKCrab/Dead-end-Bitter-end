using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameProgressionManager : MonoBehaviour
{
    [SerializeField] private VehicleController vehicleControll;
    
    public bool hasScorchedEarthUpgrade;
    public bool hasSandstormUpgrade;
    private int speedUpgradeAmount = 0;
    public int vehicleUpgradeLevel = 0;
    public int currentCheckpoint;
    public Transform[] CheckPoints;
    
    public void GetSpeedUpgrade(float speedUpgradeValue)
    {
        vehicleControll.speed += speedUpgradeValue;
        speedUpgradeAmount += 1;
    }
    
}
