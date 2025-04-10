using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeverUIUPdate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;      // Reference to the Text UI component
    [SerializeField] LeverManager leverManager;  // Reference to LeverManager to get the IMA value

    // Update is called once per frame
    void Update()
    {
        double ima = leverManager.getIMA();
        double resistance = leverManager.getResistance();
        double effort = leverManager.getEffort();
        uiText.text = $"Current resistance force: ({resistance})\r\nCurrent effort force: ({effort})\r\nIMA = AMA (ideal world) = Fr/Fe\r\nTotal IMA: ({ima.ToString("F2")})";
    }
}
