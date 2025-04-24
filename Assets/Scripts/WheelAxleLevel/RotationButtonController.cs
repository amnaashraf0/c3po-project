using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; // For UI Button
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;

public class RotationButtonController : MonoBehaviour
{
    /*[SerializeField] GameObject button;
    [SerializeField] UnityEvent onPress;
    [SerializeField] UnityEvent onRelease;

    private bool isPressed;
    private Vector3 startingPosition;*/

    // Start is called before the first frame update
    [SerializeField] GameObject button;
    [SerializeField] UnityEvent onPress;
    [SerializeField] UnityEvent onRelease;
    [SerializeField] GameObject pivot;
    //[SerializeField] RotateAround rotateAround;

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
    public void ToggleRotation()
    {
       pivot.GetComponent<RotateAround>().enabled = true; 
    }

}