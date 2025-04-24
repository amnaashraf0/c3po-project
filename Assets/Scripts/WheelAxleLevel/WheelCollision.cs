using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WheelCollision : MonoBehaviour
{
    [SerializeField] XRSocketInteractor interactor; // Assign in Inspector
    [SerializeField] WheelManager wheelManager;    // Assign in Inspector

    void Update()
    {
        if (interactor != null && wheelManager != null)
        {
            IXRSelectInteractable interactable = interactor.GetOldestInteractableSelected();
            if (interactable != null)
            {
                // Directly update currentWheel in WheelManager
                wheelManager.currentWheel = interactable.transform.gameObject;
            }
            else
            {
                wheelManager.currentWheel = null;
            }
        }
    }

    public string GetConnectedWheel()
    {
        if (interactor != null)
        {
            IXRSelectInteractable interactable = interactor.GetOldestInteractableSelected();
            return interactable != null ? interactable.transform.gameObject.name : "";
        }
        return "";
    }

    // Remove collision-related code (not needed since you're using XR interactions)
    // Delete OnCollisionEnter/Stay/Exit, getColliding(), etc.
}

