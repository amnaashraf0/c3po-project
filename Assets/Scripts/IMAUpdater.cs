using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;  // Required for Text UI

public class IMAUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;      // Reference to the Text UI component
    [SerializeField] GearManager gearManager;  // Reference to GearManager to get the IMA value


    // Update is called once per frame
    void Update()
    {
        if (gearManager != null && uiText != null)
        {
            // Directly call the getIMA() method from GearManager
            double ima = gearManager.getIMA();
            uiText.text = "Total IMA:\n" + ima.ToString("F2");  // Update the text with the IMA value
        }
    }
}