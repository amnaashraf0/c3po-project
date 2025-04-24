using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DeDrLeverPulled : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LeverManageNew leverManager;
    [SerializeField] double effortDistance;
    [SerializeField] double resDistance;
    private Vector3 startingPosition;
    private bool isActive;
    private int fulcrumPosition;
    void Start()
    {
        startingPosition = transform.localEulerAngles;
        isActive = false;
        fulcrumPosition = int.Parse(transform.parent.name.Split(' ')[1]); //get lever number

        //since the first lever is the one the catapult starts with, set it as the active lever. For some reason the angle has to change though..idk why.
        if (transform.parent.name == "Lever 1") {
            isActive = true;
            GetComponent<XRGrabInteractable>().enabled = false;
            transform.localEulerAngles = new Vector3(120, transform.localEulerAngles.y, transform.localEulerAngles.z);
            leverManager.updateDistances(effortDistance, resDistance, fulcrumPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localEulerAngles.x > 80 && !isActive)
        {
            leverManager.updateDistances(effortDistance, resDistance, fulcrumPosition);
            isActive = true;
            //setActiveLever(); This is only called after the player lets go of the lever so the lever doesn't lock mid pull
        }
        else if (isActive && effortDistance != leverManager.getEffort()) {
            unsetActiveLever();
        }
    }

    public void setActiveLever() {
        if (isActive)
        {
            GetComponent<XRGrabInteractable>().enabled = false;
            transform.localEulerAngles = new Vector3(77, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }

    public void unsetActiveLever() {
        GetComponent<XRGrabInteractable>().enabled = true;
        resetPosition();
        isActive = false;
    }

    public void resetPosition() { transform.localEulerAngles = startingPosition; }
}
