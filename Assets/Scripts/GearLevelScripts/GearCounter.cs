using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GearCounter : MonoBehaviour
{
    public GearManager manager;
    public XRSocketInteractor interactor;
    private float rotationSpeed = 0f;

    public void addGear() {
        if (manager != null)
        {
            IXRSelectInteractable interactable = interactor.GetOldestInteractableSelected();
            GameObject gear = interactable.transform.gameObject;
            manager.addSharedGears(gear, gameObject);
        }
        else {
            Debug.Log("No gear manager");
        }
    }

    public void removeGear() {
        manager.removeSharedGears(gameObject);
    }

    public void setRotationSpeed(float speed) { rotationSpeed = speed; }
    public float getRotationSpeed() { return rotationSpeed; }
}
