using UnityEngine;
using UnityEngine.UI; // For UI Button

public class WheelButtonController : MonoBehaviour
{
    [SerializeField] private WheelManager wheelManager; // Assign in Inspector
    [SerializeField] private RotateAround rotateScript;  // Assign in Inspector
    [SerializeField] private Button rotateButton;        // Assign your UI Button in Inspector

    private bool buttonPressed = false;

    void Start()
    {
        if (rotateScript != null)
            rotateScript.enabled = false; // Start with rotation off

        if (rotateButton != null)
            rotateButton.onClick.AddListener(OnButtonPressed);
    }

    void Update()
    {
        // Only allow rotation if both the button is pressed AND a wheel is present
        if (rotateScript != null)
        {
            rotateScript.enabled = buttonPressed && wheelManager != null && wheelManager.HasWheel();

            // If the wheel is removed, stop rotation and reset button state
            if (buttonPressed && (wheelManager == null || !wheelManager.HasWheel()))
            {
                buttonPressed = false;
            }
        }
    }

    void OnButtonPressed()
    {
        // Only set buttonPressed if a wheel is present
        if (wheelManager != null && wheelManager.HasWheel())
        {
            buttonPressed = true;
        }
    }
}
