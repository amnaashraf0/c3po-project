using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeverUIUPdate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;      // Reference to the Text UI component
    [SerializeField] LeverManager leverManager;  // Reference to LeverManager to get the IMA value
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        double ima = leverManager.getIMA();
        double resistance = leverManager.getResistance();
        double effort = leverManager.getEffort();
        uiText.text = $"Current resistance force: ({resistance})\r\nCurrent effort force: ({effort})\r\nTotal IMA: ({ima.ToString("F2")})";
    }
}
