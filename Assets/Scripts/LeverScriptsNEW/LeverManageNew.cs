using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class LeverManageNew : MonoBehaviour
{
    [SerializeField] GameObject catapultLever; //lever that is pulled that triggers catapult
    //[SerializeField] Animator catapultAnimator;
    [SerializeField] List<QuadraticCurve> curves;
    [SerializeField] GameObject catapultFulcrum;
    //[SerializeField] GameObject catapult; //actual catapult 
    [SerializeField] GameObject catapultUI;
    private GameObject cannonBall;
    private GameObject launchedCannonBall;
    private double effortDistance;
    private double resDistance;
    private double ima;
    private double correctIMA = 2;
    private bool cannonBallLaunched = false;
    public bool doneLaunching = false;
    // Start is called before the first frame update
    void Start()
    {
        effortDistance = 2.5;
        resDistance = 0.5;
        calculateIMA();
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if lever is pulled, if yes play the catapult animation
        if (catapultLever.GetComponent<LeverPulled>().isLeverPulled() == true)
        {
            //KEEP COMMENTED FOR NOW UNTIL NEW ANIMATOR IMPLEMENTED
            //catapultAnimator.SetBool("PlayAnim", true);
        }
        else {
            //KEEP COMMENTED FOR NOW UNTIL NEW ANIMATOR IMPLEMENTED
            //catapultAnimator.SetBool("PlayAnim", false);
        }

        /*if (cannonBallLaunched) {
            if (doneLaunching) {
                launchedCannonBall.GetComponent<LaunchCannonball>().enabled = false;
                catapult.GetComponent<XRSocketInteractor>().enabled = true;
                doneLaunching = false;
                cannonBallLaunched = false;
                launchedCannonBall.GetComponent<LaunchCannonball>().resetTime();
                launchedCannonBall = null;
            }
        }*/
    }

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
            //catapult.GetComponent<XRSocketInteractor>().enabled = false;
            cannonBallLaunched = true;
        }
    }

/*    public void setCannonBall(GameObject cannonBall) {
        this.cannonBall = cannonBall;
        if (cannonBall != null)
        {
            updateResistanceWeight(this.cannonBall.GetComponent<CannonballProperties>().getWeight());
        }
        else {
            updateResistanceWeight(0);
        }
    }*/


    public void updateDistances(double effDis, double resDis, int fulcrumPosition) {
        effortDistance = effDis;
        resDistance = resDis;
        calculateIMA();
        catapultFulcrum.GetComponent<MoveFulcrum>().setFulcrumPosition(fulcrumPosition);
    }

    public void calculateIMA() {
        ima = effortDistance / resDistance;
    }

    public double getIMA() { return ima; }
    public double getResistance() { return resDistance; }
    public double getEffort() { return effortDistance; }

    public double getCorrectIMA() { return correctIMA; }
}
