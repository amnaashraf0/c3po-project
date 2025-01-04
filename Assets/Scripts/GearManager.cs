using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GearManager : MonoBehaviour
{
    private int gearCounter = 0;
    private int[] gears = new int[2];
    private double ima = 0;
    public IMAScript IMAManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addSharedGears(GameObject gear, GameObject triggeringObject)
    {
        int teethNumber  = int.Parse(gear.transform.name.Substring(0, 2));
        if (triggeringObject.transform.name == "Pole 1")
        {
            gears[0] = teethNumber;
        }
        else if (triggeringObject.transform.name == "Pole 4")
        {
            gears[1] = teethNumber;
        }
        gearCounter++;
        if (gearCounter == 4) {
            Debug.Log("Pole 1: " + gears[0]);
            Debug.Log("Pole 4: " + gears[1]);
            ima = (double)gears[1] / (double)gears[0];
            Debug.Log("Gear IMA " + ima);
        }
    }

    public void removeSharedGears(GameObject triggeringObject) {
        gearCounter--;
        if (triggeringObject.transform.name == "Pole 1")
        {
            gears[0] = 0;
        }
        else if(triggeringObject.transform.name == "Pole 4")
        {
            gears[1] = 0;
        }
        ima = 0;
    }

    public double getIMA() { 
        return ima;
    }
}
