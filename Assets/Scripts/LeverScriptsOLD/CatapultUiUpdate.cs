using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatapultUiUpdate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;     // Reference to the Text UI component
    [SerializeField] LeverManager leverManager;  // Reference to LeverManager to get the IMA value
    double correctIMA;
    // Start is called before the first frame update
    void Start()
    {
        correctIMA = leverManager.getCorrectIMA();
        uiText.text = $"Target IMA: {correctIMA}\n\rCatapult Status:\n\rCatapult not launched";
    }

    public void setCatapultText() {
        double ima = leverManager.getIMA();
        if (ima > correctIMA)
        {
            uiText.text = $"Target IMA: ({correctIMA})\n\rCatapult Status:\n\rToo far! Try less IMA";
        }
        else if (ima < correctIMA)
        {
            uiText.text = $"Target IMA: ({correctIMA})\n\rCatapult Status:\n\rToo close! Try more IMA";
        }
        else {
            uiText.text = $"Target IMA: ({correctIMA})\n\rCatapult Status:\n\rDirect hit!";
        }
    }
}
