using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerStartOfGame : MonoBehaviour
{
    public float dialogueRange;
    public Collider startTriggerZone;
    private DialogueManager dialogueManager;
    public ChoiceDialogue choiceDialogue;
    private float distance;
    private GameObject player;
    private InteractionManager interact;
    public string interactMessage;
    
    void Start()
    {
        interact = FindObjectOfType<InteractionManager>();
        player = FindObjectOfType<Movement>().gameObject;
        choiceDialogue.isDialogueFinished = false;
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        dialogueManager.StartDialogue(choiceDialogue);
        choiceDialogue.talking = true;
        startTriggerZone.enabled = false;
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        
        if (distance <= dialogueRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueManager.isTalking && !choiceDialogue.isDialogueFinished)
            {
                dialogueManager.StartDialogue(choiceDialogue);
                choiceDialogue.talking = true;
            }
            else if (!dialogueManager.isTalking && choiceDialogue.isDialogueFinished)
            {
                dialogueManager.StartReturnMessageDialogue(choiceDialogue);
                choiceDialogue.talking = true;
            }
            else if (dialogueManager.isTalking)
            {
                if (!dialogueManager.inChoice && choiceDialogue.isDialogueFinished)
                {
                    dialogueManager.DisplayReturnMessage();
                }
                else if (!dialogueManager.inChoice && !choiceDialogue.isDialogueFinished)
                {
                    dialogueManager.DisplayNextSentenceChoice();
                }
            }
        }

        if (distance > dialogueRange && dialogueManager.isTalking && choiceDialogue.talking)
        {
            dialogueManager.CancelDialogue();
            choiceDialogue.talking = false;
        }
    }

    private void OnMouseOver()
    {
        if (distance <= dialogueRange && !dialogueManager.isTalking && enabled)
        {
            interact.ShowInteractMessage(interactMessage);
        }
    }

    private void OnMouseExit()
    {
        interact.HideInteractMessage();
    }
}
