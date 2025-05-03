using System.Collections.Generic;
using UnityEngine;

public class WheelManager : MonoBehaviour
{
    public GameObject currentWheel = null; // Public for direct access
    private const float axleRadius = 0.5f;

    public GameObject GetCurrentWheel() => currentWheel;
    public string GetCurrentWheelName() => currentWheel != null ? currentWheel.name : "";
    public bool HasWheel() => currentWheel != null;

    public double correctIMA = 3.25 / axleRadius;

    public double getIMA()
    {
        if (currentWheel == null) return 0.0;

        float wheelRadius = 0f;
        string wheelName = currentWheel.name;

        if (wheelName == "4 (320mm Travel) Anti-Static Wheel")
            wheelRadius = 4.0f;
        else if (wheelName == "3.25 (260mm Travel) Anti-Static Wheel")
            wheelRadius = 3.25f;
        else if (wheelName == "2.75 (220mm Travel) Anti-Static Wheel")
            wheelRadius = 2.75f;
        else
            return 0.0;

        return wheelRadius / axleRadius;
    }
}
