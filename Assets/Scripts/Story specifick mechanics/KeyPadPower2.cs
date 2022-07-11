using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadPower2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NumberInput;
    [SerializeField] private int passwordLength;
    [SerializeField] private string correctPassword;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float interactionRange;
    [SerializeField] private Animator anim;
    [SerializeField] private VehicleUpgradeObject vehicleUpgrade;
    [SerializeField] private QuestPuzzle2 quest;
    [SerializeField] private DialogueTrigger lockedDialogue;
    [SerializeField] private ChangeWaypoint waypoint;
    [SerializeField] private ChangeActiveQuest activeQuest;
    [SerializeField] private Collider generatorCollider;
    public string interactMessage;
    private bool inKeyPad;
    public bool correctCodePuzzle2;
    private MouseLook fpsView;
    private InteractionManager interact;
    

    private void Start()
    {
        correctCodePuzzle2 = false;
        fpsView = FindObjectOfType<MouseLook>();
        interact = FindObjectOfType<InteractionManager>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E))
        {
            return;
        }

        if (Physics.CheckSphere(transform.position, interactionRange, playerLayer) && inKeyPad)
        {
            inKeyPad = false;
            anim.SetTrigger("Close keypad");
            Cursor.lockState = CursorLockMode.Locked;
            fpsView.enabled = true;
        }
        else if (Physics.CheckSphere(transform.position, interactionRange, playerLayer) && !inKeyPad)
        {
            inKeyPad = true;
            anim.SetTrigger("Open keypad");
            Cursor.lockState = CursorLockMode.None;
            fpsView.enabled = false;
        }
    }

    private void OnMouseOver()
    {
        if (Physics.CheckSphere(transform.position, interactionRange, playerLayer) && enabled)
        {
            interact.ShowInteractMessage(interactMessage);
        }
    }

    private void OnMouseExit()
    {
        interact.HideInteractMessage();
    }

    public void OkButton()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        if (NumberInput.text == correctPassword)
        {
            lockedDialogue.enabled = false;
            correctCodePuzzle2 = true;
            waypoint.IncramentWaypointExternal();
            activeQuest.IncramentActiveQuestExternal();
            vehicleUpgrade.enabled = true;
            inKeyPad = false;
            anim.SetTrigger("Close keypad");
            Cursor.lockState = CursorLockMode.Locked;
            generatorCollider.enabled = true;
            fpsView.enabled = true;
            KeyPadPower2 thisKeypad = GetComponent<KeyPadPower2>();
            enabled = false;
            for (int i = 0; i < quest.waypoint.Length; i++)
            {
                Destroy(quest.waypoint[i]);
                Destroy(quest.meter[i]);
            }
        }
    }
    public void BackSpaceButton()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        NumberInput.text = "";
    }
    public void Button1()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "1";
    }
    public void Button2()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "2";
    }
    public void Button3()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "3";
    }
    public void Button4()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "4";
    }
    public void Button5()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "5";
    }
    public void Button6()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "6";
    }
    public void Button7()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "7";
    }
    public void Button8()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "8";
    }
    public void Button9()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "9";
    }
    
}
