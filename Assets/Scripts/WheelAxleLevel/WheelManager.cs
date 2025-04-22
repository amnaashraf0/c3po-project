using UnityEngine;

public class WheelManager : MonoBehaviour
{
    [SerializeField] private WheelCollision wheelCollision; // Reference to the WheelCollision script on the barrel collider
    private GameObject currentWheel = null;

    // Axle radius is always 0.5 inches
    private const float axleRadius = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (wheelCollision.getColliding())
        {
            string wheelName = wheelCollision.getCollidingString();
            GameObject foundWheel = GameObject.Find(wheelName);

            if (foundWheel != null && foundWheel != currentWheel)
            {
                currentWheel = foundWheel;
                Debug.Log("Wheel placed on barrel: " + currentWheel.name);
            }
        }
        else
        {
            if (currentWheel != null)
            {
                Debug.Log("Wheel removed from barrel: " + currentWheel.name);
                currentWheel = null;
            }
        }
    }

    // Returns the current wheel GameObject, or null if none
    public GameObject GetCurrentWheel()
    {
        return currentWheel;
    }

    // Returns the name of the current wheel, or empty string if none
    public string GetCurrentWheelName()
    {
        return currentWheel != null ? currentWheel.name : "";
    }

    // Returns true if a wheel is currently on the barrel
    public bool HasWheel()
    {
        return currentWheel != null;
    }

    // Returns the IMA for the current wheel and axle system
    public double getIMA()
    {
        float wheelRadius = 0f;
        if (currentWheel == null)
            return 0.0;

        string wheelName = currentWheel.name;

        // Assign radius based on wheel name
        if (wheelName == "4 (320mm Travel) Anti-Static Wheel")
            wheelRadius = 4.0f;
        else if (wheelName == "3.25 (260mm Travel) Anti-Static Wheel")
            wheelRadius = 3.25f;
        else if (wheelName == "2.75 (220mm Travel) Anti-Static Wheel")
            wheelRadius = 2.75f;
        else
            return 0.0; // this doesn't reach here

        // IMA = radius of wheel / radius of axle
        return wheelRadius / axleRadius;
    }
}
