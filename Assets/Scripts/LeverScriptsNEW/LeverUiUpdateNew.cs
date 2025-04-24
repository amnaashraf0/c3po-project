using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeverUiUpdateNew : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;      // Reference to the Text UI component
    [SerializeField] LeverManageNew leverManager;  // Reference to LeverManager to get the IMA value

    // Update is called once per frame
    void Update()
    {
        double ima = leverManager.getIMA();
        double resistance = leverManager.getResistance();
        double effort = leverManager.getEffort();
        uiText.text = $"Current effort distance: ({effort}) m\r\nCurrent resistance distance: ({resistance}) m\r\nIMA = De/Dr\r\nTotal IMA: ({ima.ToString("F2")})";
    }
}
