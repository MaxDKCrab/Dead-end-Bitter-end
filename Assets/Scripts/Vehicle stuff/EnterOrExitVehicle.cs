using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class EnterOrExitVehicle : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject vehicleCamera;
    [SerializeField] private float carEnterRange = 10f;
    [SerializeField] private Vector3 exitCarPosition;
    [SerializeField] private QuestWaypoint qw;
    [SerializeField] private GameObject mouseIcon;

    private SettingsController settings;
    private FMOD.Studio.EventInstance motorSound;
    private Transform playerTransform;
    public LayerMask PlayerLayer;
    public bool inCar;
    private bool isInCarRange;
    private InteractionManager interact;
    public string interactMessage;
    private bool enterCarCD = false;
    void Start()
    {
        settings = FindObjectOfType<SettingsController>();
        interact = FindObjectOfType<InteractionManager>();
        playerTransform = player.GetComponent<Transform>();
        motorSound = FMODUnity.RuntimeManager.CreateInstance("event:/Vehicle/Motor");
    }

    private void Update()
    {
        isInCarRange = Physics.CheckSphere(transform.position, carEnterRange, PlayerLayer);

        if (inCar && Input.GetKeyDown(KeyCode.Mouse0) && enterCarCD && !settings.inMenu)
        {
            ExitCar();
            StartCoroutine(Pause());
        }
    }
    
    private void OnMouseOver()
    {
        if (isInCarRange && !inCar)
        {
            interact.ShowInteractMessage(interactMessage);
            mouseIcon.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (isInCarRange && !inCar && !enterCarCD && !settings.inMenu)
        {
            EnterCar();
            StartCoroutine(Pause());
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.5f);
        enterCarCD = !enterCarCD;
    }

    private void OnMouseExit()
    {
        interact.HideInteractMessage();
        mouseIcon.SetActive(false);
    }

    private void EnterCar()
    {
        inCar = true;
        qw.EnterVehicleToggle();
        player.SetActive(false);
        player.transform.position = new Vector3(1000, 1000, 1000);
        vehicleCamera.SetActive(true);
        interact.HideInteractMessage();
        motorSound.start();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Vehicle/Vehicle Enter");
    }

    public void ExitCar()
    {
        inCar = false;
        vehicleCamera.SetActive(false);
        playerTransform.position = transform.position + exitCarPosition;
        player.SetActive(true);
        motorSound.stop(STOP_MODE.IMMEDIATE);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Vehicle/Vehicle Exit");
    }
    public void ExitCarOnDeath()
    {
        inCar = false;
        vehicleCamera.SetActive(false);
        playerTransform.position = transform.position + exitCarPosition;
        player.SetActive(true);
        motorSound.stop(STOP_MODE.IMMEDIATE);
        enterCarCD = !enterCarCD;
        StopAllCoroutines();
    }
}
