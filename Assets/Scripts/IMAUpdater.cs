using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required for Text UI

public class IMAUpdater : MonoBehaviour
{
    public IMAScript imaScript;  // Reference to IMAScript to get the IMA value
    public Text uiText;          // Reference to the Text UI component
    public GearManager gearManager;  // Reference to GearManager to get the IMA value

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gearManager != null && uiText != null)
        {
            // Directly call the getIMA() method from GearManager
            double ima = gearManager.getIMA();
            uiText.text = "" + ima.ToString("F2");  // Update the text with the IMA value
        }
    }
}