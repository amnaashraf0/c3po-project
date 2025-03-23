using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GetCannonBall : MonoBehaviour
{
    public LeverManager manager;
    public XRSocketInteractor interactor;

    public void addCannonball()
    {
        if (manager != null)
        {
            IXRSelectInteractable interactable = interactor.GetOldestInteractableSelected();
            GameObject cannonBall = interactable.transform.gameObject;
            manager.setCannonBall(cannonBall);
        }
        else
        {
            Debug.Log("No gear manager");
        }
    }

    public void removeCannonball()
    {
        manager.setCannonBall(null);
    }
}
