using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GearManager : MonoBehaviour
{
    private int gearCounter = 0;
    private int[] gears = new int[4];
    private double ima = 0;
    private Boolean gearTrainComplete = false;
    //set correctIMA here
    private double correctIMA = 60.0 / 36;
    public IMAScript IMAManager;
    [SerializeField] List<GameObject> poles;
    [SerializeField] List<ParticleSystem> fire;
    [SerializeField] GameObject meat;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < fire.Count; i++)
        {
            ParticleSystem ps = fire[i];
            var main = ps.main;
            main.startLifetime = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the gears on all poles only if gearcount == 4 and the first gear is colliding with the next gear to ensure they dont spin mid movement
        if (gearCounter == 4)
        {
            for (int i = 0; i < poles.Count; i++)
            {
                if (poles[0].GetComponent<PoleMover>().isGearColliding())
                {
                    float rotSpeed = poles[i].GetComponent<GearCounter>().getRotationSpeed();
                    poles[i].transform.GetChild(0).Rotate(0, 0, rotSpeed);
                }
            }
        }
    }

    public void addSharedGears(GameObject gear, GameObject triggeringObject)
    {
        int teethNumber  = int.Parse(gear.transform.name.Substring(0, 2));
        string poleName = triggeringObject.transform.name;
        //get last character of pole name, which is the number of the pole and set the gear array accordingly
        gears[int.Parse(poleName.Substring(poleName.Length - 1))-1] = teethNumber;

        gearCounter++;
        if (gearCounter == 4) {
            ima = (double)gears[3] / (double)gears[0];
            gearTrainComplete = true;
            setGearRotationSpeed();
            setFireLifeTime();
            meat.GetComponent<ChangeMeatColor>().setMeatMaterial();
            //Debug.Log("Gear IMA " + ima);
        }
    }

    public void removeSharedGears(GameObject triggeringObject) {
        gearTrainComplete = false;
        gearCounter--;
        string poleName = triggeringObject.transform.name;
        gears[int.Parse(poleName.Substring(poleName.Length - 1))-1] = 0;
        ima = 0;
        setFireLifeTime();
    }

    private void setGearRotationSpeed() {
        for (int i = 0; i < poles.Count; i++)
        {
            float rotationSpeed = 0f;
            if (i == 0)
            {
                rotationSpeed = 1f;
                poles[i].GetComponent<GearCounter>().setRotationSpeed(rotationSpeed);
            }
            else
            {
                rotationSpeed = poles[i - 1].GetComponent<GearCounter>().getRotationSpeed() * -1;
                double gearRatio = (double)gears[i] / (double)gears[i - 1];
                rotationSpeed = rotationSpeed / (float)gearRatio;
                poles[i].GetComponent<GearCounter>().setRotationSpeed(rotationSpeed);
            }
        }
    }

    private void setFireLifeTime() {
        //sets the fire height based on ima
        for (int i = 0; i < fire.Count; i++) { 
            ParticleSystem ps = fire[i];
            var main = ps.main;
            var emission = ps.emission;
            //this first if statement is the correct gear combo 
            if (ima == correctIMA)
            {
                main.startLifetime = 1f;
                emission.rateOverTime = 20;
            }
            else if (ima == 0)
            {
                main.startLifetime = 0f;
            }
            else if (ima < correctIMA)
            {
                main.startLifetime = 0.4f;
                emission.rateOverTime = 10;
            }
            else {
                main.startLifetime = 1.5f;
                emission.rateOverTime = 30;
            }
        }
    }

    public double getIMA() { return ima;}

    public int[] gearList() { return gears; }

    public int getGearCount() {return gearCounter;}

    public bool getTrainComplete() { return gearTrainComplete; }

    public double getCorrectIMA() { return correctIMA; }
}
