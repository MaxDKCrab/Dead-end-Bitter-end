using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControls : MonoBehaviour
{
    [SerializeField] private EnterOrExitVehicle car;
    [SerializeField] private GameObject drivePrompt;
    private void Update()
    {
        ToggleControl();
    }

    public void ToggleControl()
    {
        if (car.inCar && Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ControlTimer());
        }
    }

    IEnumerator ControlTimer()
    {
        drivePrompt.SetActive(true);
        yield return new WaitForSeconds(4);
        drivePrompt.SetActive(false);
    }
}
