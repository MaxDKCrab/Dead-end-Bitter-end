using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SandstormDamageField : MonoBehaviour
{
    public float damagePerFrame;
    public LayerMask playerLayer;
    public LayerMask vehicleLayer;
    private PlayerHealthManager playerHealth;
    private Collider damageField;
    private EnterOrExitVehicle enterVehicle;

    private GameProgressionManager gameProgress;

    private void Start()
    {
        enterVehicle = FindObjectOfType<EnterOrExitVehicle>();
        gameProgress = FindObjectOfType<GameProgressionManager>();
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        damageField = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        if (Physics.CheckBox(damageField.bounds.center,damageField.bounds.extents,quaternion.Euler(0),playerLayer) && !enterVehicle.inCar)
        {
            playerHealth.TakeDamage(damagePerFrame);
        }
        else if (Physics.CheckBox(damageField.bounds.center,damageField.bounds.extents,quaternion.Euler(0),vehicleLayer) && enterVehicle.inCar)
        {
            if (!gameProgress.hasSandstormUpgrade)
            {
                playerHealth.TakeDamage(damagePerFrame);
            }
        }
    }
}
