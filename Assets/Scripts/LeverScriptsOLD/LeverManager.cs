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
    [SerializeField] List<QuadraticCurve> curves;
    [SerializeField] GameObject catapult; //actual catapult 
    [SerializeField] GameObject catapultUI;
    private GameObject cannonBall;
    private GameObject launchedCannonBall;
    private double effortWeight;
    private double resWeight;
    private double ima;
    private double correctIMA = 2;
    private bool cannonBallLaunched = false;
    public bool doneLaunching = false;
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
                launchedCannonBall.GetComponent<LaunchCannonball>().enabled = false;
                catapult.GetComponent<XRSocketInteractor>().enabled = true;
                doneLaunching = false;
                cannonBallLaunched = false;
                launchedCannonBall.GetComponent<LaunchCannonball>().resetTime();
                launchedCannonBall = null;
            }
        }
    }

    //this is only called by the animation event
    public void launchCannonBall() {
        catapultUI.GetComponent<CatapultUiUpdate>().setCatapultText();
        if (cannonBall != null) {
            //necessary because cannonBall is set to null once it leaves the lever. need to maintain access to it, so store in seperate variable.
            launchedCannonBall = cannonBall;
            if (ima > correctIMA)
            {
                launchedCannonBall.GetComponent<LaunchCannonball>().setCurve(curves[0]);
            }
            else if (ima == correctIMA)
            {
                launchedCannonBall.GetComponent<LaunchCannonball>().setCurve(curves[1]);
            }
            else {
                launchedCannonBall.GetComponent<LaunchCannonball>().setCurve(curves[2]);
            }
            launchedCannonBall.GetComponent<LaunchCannonball>().enabled = true;
            catapult.GetComponent<XRSocketInteractor>().enabled = false;
            cannonBallLaunched = true;
        }
    }

    public void setCannonBall(GameObject cannonBall) {
        this.cannonBall = cannonBall;
        if (cannonBall != null)
        {
            updateResistanceWeight(this.cannonBall.GetComponent<CannonballProperties>().getWeight());
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

    public double getCorrectIMA() { return correctIMA; }
}
