using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WheelCollision: MonoBehaviour
{
    [SerializeField] XRSocketInteractor interactor;
    [SerializeField] WheelManager wheelManager; 

    // Start is called before the first frame update
    Boolean isColliding = false;
    String colliding = "";

    void Update()
    {
        // Returns the GameObject currently attached to the interactor, or null if none.
        if (interactor != null)
        {
            IXRSelectInteractable interactable = interactor.GetOldestInteractableSelected();
            if (interactable != null)
            {
                GameObject connectedWheel = interactable.transform.gameObject;
                Debug.Log(connectedWheel.name);
                //wheelManager.currentWheel = interactable.transform.gameObject;
            }
            else
            {
                Debug.Log("null");
            }
        }
    }
    public String GetConnectedWheel()
    {
        if (interactor != null)
        {
            IXRSelectInteractable interactable = interactor.GetOldestInteractableSelected();
            if (interactable != null)
            {
                GameObject connectedWheel = interactable.transform.gameObject;
                return (connectedWheel.name);
            }
            else { return null; }
        }
        else
        {
            return "noWheel";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Wheel"))
        {
            colliding = collision.gameObject.name;
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("Wheel"))
        {
            isColliding = true;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
        colliding = collision.gameObject.name;
    }

    public Boolean getColliding() { return isColliding; }

    public String getCollidingString() { return colliding; }
}
