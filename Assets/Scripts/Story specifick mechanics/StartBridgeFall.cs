using System;
using Unity.VisualScripting;
using UnityEngine;

    public class StartBridgeFall : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private InteractionManager interact;

        public bool withinRange;

        private void OnTriggerEnter(Collider other)
        {
            withinRange = true;
            interact.ShowInteractMessage("Press E to interact");
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

            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.enabled = true;
            }
        }
    }
