using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActiveQuestTrigger : MonoBehaviour
{

    [SerializeField] private Collider thisColl;
    [SerializeField] public ChangeActiveQuest ca;
    private void OnTriggerEnter(Collider other)
    {
        
        ca.IncramentActiveQuestExternal();
        thisColl.enabled = false;
        Destroy(this);
    }
}
