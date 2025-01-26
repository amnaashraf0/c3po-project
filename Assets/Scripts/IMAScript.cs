using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMAScript : MonoBehaviour
{
    public GearManager gearManager;
    // other managers ex: incline, screw
    private double totalIMA = 0;
    private double gearTrainIMA = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gearTrainIMA = gearManager.getIMA();
        //add other variables as they are developed ex. incline ima, screw ima
        totalIMA = gearTrainIMA;
        Debug.Log(totalIMA);
    }
}
