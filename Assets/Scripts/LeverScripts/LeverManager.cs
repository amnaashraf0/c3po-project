using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class LeverManager : MonoBehaviour
{
    [SerializeField] GameObject weightText;
    [SerializeField] GameObject catapultLever; //lever that is pulled that triggers catapult
    [SerializeField] Animator catapultAnimator;
    private double effortWeight;
    private double resWeight;
    private GameObject cannonBall;
    private double ima;
    private bool cannonBallLaunched = false;
    public bool doneLaunching = false;
    private InteractionLayerMask originalMask;
    // Start is called before the first frame update
    void Start()
    {
        effortWeight = 10;
        resWeight = 0;
        ima = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if lever is pulled, if ues play the catapult animation
        if (catapultLever.GetComponent<LeverPulled>().isLeverPulled() == true)
        {
            //Debug.Log("Play animation");
            catapultAnimator.SetBool("PlayAnim", true);
        }
        else {
            //Debug.Log("Don't play animation");
            catapultAnimator.SetBool("PlayAnim", false);
        }

        if (cannonBallLaunched) {
            if (doneLaunching) {
                cannonBall.GetComponent<XRGrabInteractable>().interactionLayers = originalMask;
                cannonBall.GetComponent<XRGeneralGrabTransformer>().enabled = true;
                cannonBall.GetComponent<LaunchCannonball>().enabled = false;
                cannonBallLaunched = false;
            }
        }
    }

    public void launchCannonBall() {
        //Debug.Log("Launched cannon ball");
        if (cannonBall != null) {
            //cannonBall.GetComponent<XRGrabInteractable>().enabled = false;
            var grab = cannonBall.GetComponent<XRGrabInteractable>();
            grab.interactionLayers = 0;
            cannonBall.GetComponent<XRGeneralGrabTransformer>().enabled = false;
            cannonBall.GetComponent<LaunchCannonball>().enabled = true;
            cannonBallLaunched = true;
        }
    }

    public void setCannonBall(GameObject cannonBall) { 
        this.cannonBall = cannonBall;
        if (cannonBall != null)
        {
            updateResistanceWeight(this.cannonBall.GetComponent<CannonballProperties>().getWeight());
            originalMask = cannonBall.GetComponent<XRGrabInteractable>().interactionLayers;
        }
        else {
            updateResistanceWeight(0);
        }
    }

    public void updateEffortWeight(double effWeight) {
        effortWeight = effWeight;
        weightText.GetComponent<TextMeshPro>().text = effWeight.ToString() + " lb";
        if (effortWeight > 0) {
            calculateIMA();
        }
    }

    public void updateResistanceWeight(double resWeight) {
        this.resWeight = resWeight;
        if (effortWeight > 0) {
            calculateIMA();
        }
    }

    public void calculateIMA() {
        ima = resWeight / effortWeight;
    }

    public double getIMA() { return ima; }
    public double getResistance() { return resWeight; }

    public double getEffort() { return effortWeight; }
}
