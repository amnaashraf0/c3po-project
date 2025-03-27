using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeverManager : MonoBehaviour
{
    [SerializeField] GameObject weightText;
    private double effortWeight;
    private double resWeight;
    private GameObject cannonBall;
    private double ima;
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
}
