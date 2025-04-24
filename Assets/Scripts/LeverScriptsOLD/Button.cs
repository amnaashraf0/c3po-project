using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject button;
    [SerializeField] LeverManager leverManager;
    [SerializeField] double effortWeight;
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
        if (!isPressed) {
            button.transform.localPosition = new Vector3(startingPosition.x, startingPosition.y - 0.015f, startingPosition.z);
            //presser = other.gameObject;
            onPress.Invoke();
            //isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser) {
            button.transform.localPosition = startingPosition;
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void setEffortWeight() {
        leverManager.updateEffortWeight(effortWeight);
    }


}
