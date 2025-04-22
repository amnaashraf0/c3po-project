using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;  // Required for Text UI
using System.Collections;
using TMPro;
using UnityEngine;

public class UpdateIMA : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;      // Reference to the Text UI component
    [SerializeField] WheelManager wheelManager;   // Reference to WheelManager to get the IMA value
    private string setText = "Equation for wheel and axle IMA: \r\n" + "(radius of wheel) / (radius of axle)\r\n";

    // Update is called once per frame
    void Update()
    {
        if (wheelManager != null && uiText != null)
        {
            double ima = wheelManager.getIMA();
            string wheelName = wheelManager.GetCurrentWheelName();
            float wheelRadius = 0f;
            float axleRadius = 0.5f;

            // Determine the wheel radius for display
            if (wheelName == "4 (320mm Travel) Anti-Static Wheel")
                wheelRadius = 4.0f;
            else if (wheelName == "3.25 (260mm Travel) Anti-Static Wheel")
                wheelRadius = 3.25f;
            else if (wheelName == "2.75 (220mm Travel) Anti-Static Wheel")
                wheelRadius = 2.75f;

            uiText.text = setText;

            if (ima != 0 && wheelManager.HasWheel())
            {
                uiText.text += $"Current equation: ({wheelRadius}) / ({axleRadius}) = {ima.ToString("F2")}\r\n";
            }
            else
            {
                uiText.text += "Current equation: Wheel not placed on barrel\r\n";
            }

            uiText.text += "Total IMA: " + ima.ToString("F2");
        }
    }
}
