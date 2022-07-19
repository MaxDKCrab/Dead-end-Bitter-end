using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public Item item;
    private InteractionManager interact;
    private bool withinRange;
    public string interactMessage = "Press E to pick up item";

    private void Start()
    {
        interact = InteractionManager.instance;
    }

    void Update()
    {
        if (withinRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(item.name + " picked up");
            bool wasPickedUp = Inventory.instance.Add(item);

            if (wasPickedUp)
            {
                interact.HideInteractMessage();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        withinRange = true;
        interact.ShowInteractMessage(interactMessage);
    }

    private void OnTriggerExit(Collider other)
    {
        withinRange = false;
        interact.HideInteractMessage();
    }
}
