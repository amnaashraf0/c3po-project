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
    [SerializeField] Animator catapultAnimator;
    [SerializeField] List<QuadraticCurve> curves;
    [SerializeField] GameObject catapultFulcrum;
    [SerializeField] GameObject catapultUI;
    [SerializeField] GameObject cannonBall;
    [SerializeField] GameObject catapult;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] List<GameObject> slimes;
    private double effortDistance;
    private double resDistance;
    private double ima;
    private double correctIMA = 2;
    private bool cannonBallLaunched = false;
    private bool timerRunning = false;
    private float timer = 2f; //number of seconds for slimes to respawn
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
            catapultAnimator.SetBool("PlayAnim", true);
        }
        else {
            catapultAnimator.SetBool("PlayAnim", false);
        }

        if (cannonBallLaunched)
        {
            if (doneLaunching)
            {
                cannonBall.GetComponent<LaunchCannonballNew>().enabled = false;
                catapult.GetComponent<XRSocketInteractor>().enabled = true;
                doneLaunching = false;
                cannonBallLaunched = false;
                cannonBall.GetComponent<LaunchCannonballNew>().resetTime();
                if (ima == correctIMA)
                {
                    explosion.Play();
                    foreach (GameObject slime in slimes) {
                        slime.GetComponent<Rigidbody>().AddExplosionForce(-800000f, slime.transform.position, 5);
                        timerRunning = true;
                    }
                }
            }
        }

        //reset the slimes position after timer runs out
        if (timerRunning) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                foreach (GameObject slime in slimes) {
                    slime.GetComponent<RespawnObject>().resetPosition();
                }
                timerRunning = false;
                timer = 2f;
            }
        }
    }

    public void launchCannonBall() {
        catapultUI.GetComponent<CatapultUiUpdateNew>().setCatapultText();

        if (ima > correctIMA)
        {
            cannonBall.GetComponent<LaunchCannonballNew>().setCurve(curves[0]);
            cannonBall.GetComponent<LaunchCannonballNew>().setSpeed(0.7f);
        }
        else if (ima == correctIMA)
        {
            cannonBall.GetComponent<LaunchCannonballNew>().setCurve(curves[1]);
            cannonBall.GetComponent<LaunchCannonballNew>().setSpeed(1.3f);

        }
        else {
            cannonBall.GetComponent<LaunchCannonballNew>().setCurve(curves[2]);
            cannonBall.GetComponent<LaunchCannonballNew>().setSpeed(1.5f);

        }
        cannonBall.GetComponent<LaunchCannonballNew>().enabled = true;
        catapult.GetComponent<XRSocketInteractor>().enabled = false;
        cannonBallLaunched = true;
    }


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
