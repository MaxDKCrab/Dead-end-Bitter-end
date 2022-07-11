using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject interactionMessage;
    private TextMeshProUGUI interactText;
  
    void Start()
    {
        interactText = interactionMessage.GetComponentInChildren<TextMeshProUGUI>();
    }

    
    public void ShowInteractMessage(string interactMessage)
    {
        interactionMessage.SetActive(true);
        interactText.text = interactMessage;
    }

    public void HideInteractMessage()
    {
        interactionMessage.SetActive(false);
    }
    
}
