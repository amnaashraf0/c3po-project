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
    public IMAScript IMAManager;
    [SerializeField] List<GameObject> poles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gearCounter == 4)
        {
            for (int i = 0; i < poles.Count; i++)
            {
                float rotSpeed = poles[i].GetComponent<GearCounter>().getRotationSpeed();
                poles[i].transform.GetChild(0).Rotate(0, 0, rotSpeed);
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
            //Debug.Log("Gear IMA " + ima);
        }
    }

    public void removeSharedGears(GameObject triggeringObject) {
        gearTrainComplete = false;
        gearCounter--;
        string poleName = triggeringObject.transform.name;
        gears[int.Parse(poleName.Substring(poleName.Length - 1))-1] = 0;
        ima = 0;
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
                poles[i].GetComponent<GearCounter>().setRotationSpeed(rotationSpeed);
            }
        }
    }

    public double getIMA() { return ima;}

    public int[] gearList() { return gears; }

    public int getGearCount() {return gearCounter;}

    public bool getTrainComplete() { return gearTrainComplete; }
}
