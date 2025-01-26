using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;  // Required for Text UI

public class IMAUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;      // Reference to the Text UI component
    [SerializeField] GearManager gearManager;  // Reference to GearManager to get the IMA value
    private string setText = "Equation for gear train IMA: \r\n" + "(# of teeth on last gear) / (# of teeth on first gear)\r\n";


    // Update is called once per frame
    void Update()
    {
        if (gearManager != null && uiText != null)
        {
            int[] gears = gearManager.gearList();
            // Directly call the getIMA() method from GearManager
            double ima = gearManager.getIMA();
            uiText.text = setText;
            if (ima != 0)
            {

                uiText.text += $"Current equation: ({gears[1]}) / ({gears[0]}) = {ima.ToString("F2")}\r\n";
            }
            else if (ima == 0) {
                uiText.text += "Current equation: Gear train not fully assembled\r\n";
            }
            uiText.text += "Total IMA: " + ima.ToString("F2");
        }
    }
}