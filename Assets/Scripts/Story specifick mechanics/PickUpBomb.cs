using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpBomb : MonoBehaviour
{

    [SerializeField] private QuestManager qm;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject bomb;
    [SerializeField] private InteractionManager interact;
    [SerializeField] private GameObject bombObject;
    [SerializeField] private BoxCollider thisColl;
    
    public bool withinRange;
    private void OnTriggerEnter(Collider other)
    {
        withinRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interact.HideInteractMessage();
        withinRange = false;
    }

    private void Update()
    {
        if (!withinRange)
        {
            return;
        }

        PickUp();
    }

    private void PickUp()
    {   
        interact.ShowInteractMessage("Press E to pick up bomb");
        
        if (withinRange && Input.GetKeyDown(KeyCode.E))
        {
            interact.HideInteractMessage();
            qm.hasBomb = true;
            dialogue.SetActive(true);
            bombObject.SetActive(false);
            thisColl.size = new Vector3(0.01f, 0.01f, 0.01f);
        }
    }
}
