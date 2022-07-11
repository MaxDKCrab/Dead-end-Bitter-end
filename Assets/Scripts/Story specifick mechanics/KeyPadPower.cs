using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadPower : MonoBehaviour
{
    [SerializeField] private VehicleUpgradeObject vehicleUpgrade;
    [SerializeField] private DialogueTrigger lockedDialogue;
    [SerializeField] private TextMeshProUGUI NumberInput;
    [SerializeField] private int passwordLength;
    [SerializeField] private string correctPassword;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float interactionRange;
    [SerializeField] private Animator anim;
    public string interactMessage;
    private bool inKeyPad;
    public bool correctCode;
    private MouseLook fpsView;
    private InteractionManager interact;
    public GameObject dialogueTriggerOnComplete;
    public Light lampPost1;
    public Light lampPost2;
    
    

    private void Start()
    {
        correctCode = false;
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
            FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Zoop");
            Cursor.lockState = CursorLockMode.Locked;
            fpsView.enabled = true;
        }
        else if (Physics.CheckSphere(transform.position, interactionRange, playerLayer) && !inKeyPad)
        {
            inKeyPad = true;
            anim.SetTrigger("Open keypad");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Zoop");
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
            vehicleUpgrade.enabled = true;
            inKeyPad = false;
            correctCode = true;
            anim.SetTrigger("Close keypad");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Zoop");
            Cursor.lockState = CursorLockMode.Locked;
            fpsView.enabled = true;
            KeyPadPower thisKeypad = GetComponent<KeyPadPower>();
            dialogueTriggerOnComplete.SetActive(true);
            thisKeypad.enabled = false;
            lampPost1.color = Color.green;
            lampPost2.color = Color.green;
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
