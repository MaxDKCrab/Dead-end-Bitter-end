using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public GameObject interactionBox;
    [SerializeField] private float interactionRange = 10f;
    private bool isInInteractRange;
    private GameObject player;
    private float distance;

    private void Start()
    {
        player = FindObjectOfType<Movement>().gameObject;
    }

    private void OnMouseOver()
    {
        if (distance <= interactionRange)
        {
            interactionBox.SetActive(true);
        }
    }
    

    private void OnMouseExit()
    {
        interactionBox.SetActive(false);
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
    }
}
