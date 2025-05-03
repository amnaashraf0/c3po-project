using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;  // Required for Text UI

public class UpdateIMA : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;     // Assign in Inspector
    [SerializeField] WheelManager wheelManager;  // Assign in Inspector
    [SerializeField] GameObject rotater;
    [SerializeField] List<ParticleSystem> particles;
    private string setText = "Equation for wheel and axle IMA: \r\n(radius of wheel) / (radius of axle)\r\n";

    void Update()
    {
        if (wheelManager != null && uiText != null)
        {
            double ima = wheelManager.getIMA();
            string wheelName = wheelManager.GetCurrentWheelName();
            float wheelRadius = 0f;
            float axleRadius = 0.5f;

            if (wheelName == "4 (320mm Travel) Anti-Static Wheel")
                wheelRadius = 4.0f;
            else if (wheelName == "3.25 (260mm Travel) Anti-Static Wheel")
                wheelRadius = 3.25f;
            else if (wheelName == "2.75 (220mm Travel) Anti-Static Wheel")
                wheelRadius = 2.75f;

            uiText.text = setText;

            if (ima != 0 && wheelManager.HasWheel())
            {
                uiText.text += $"Current equation: ({wheelRadius}) / ({axleRadius}) = {ima:F2}\r\n";
            }
            else
            {
                uiText.text += "Current equation: Wheel not placed on barrel\r\n";
                rotater.GetComponent<RotateAround>().enabled = false;
                foreach (ParticleSystem p in particles) {
                    p.Stop();
                }
            }

            uiText.text += "Total IMA: " + ima.ToString("F2");
        }
    }
}

