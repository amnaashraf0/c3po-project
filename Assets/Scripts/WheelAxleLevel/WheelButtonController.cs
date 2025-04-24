using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; // For UI Button
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;

public class WheelButtonController : MonoBehaviour
{
    public class RotationButtonController : MonoBehaviour
    {

        public class Button : MonoBehaviour
        {
            // Start is called before the first frame update
            [SerializeField] GameObject button;
            [SerializeField] UnityEvent onPress;
            [SerializeField] UnityEvent onRelease;
            private GameObject presser;
            private bool isPressed;
            private Vector3 startingPosition;
            void Start()
            {
                isPressed = false;
                startingPosition = this.gameObject.transform.localPosition;
            }

            private void OnTriggerEnter(Collider other)
            {
                if (!isPressed)
                {
                    button.transform.localPosition = new Vector3(startingPosition.x, startingPosition.y - 0.015f, startingPosition.z);
                    presser = other.gameObject;
                    onPress.Invoke();
                    isPressed = true;
                }
            }

            private void OnTriggerExit(Collider other)
            {
                if (other.gameObject == presser)
                {
                    button.transform.localPosition = startingPosition;
                    onRelease.Invoke();
                    isPressed = false;
                }
            }

            /*public void setEffortWeight()
            {
                leverManager.updateEffortWeight(effortWeight);
            }*/


        }
    }
}

/*
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
}*/
