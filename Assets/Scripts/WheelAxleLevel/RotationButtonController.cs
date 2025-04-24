using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class RotationButtonController : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] UnityEvent onPress;
    [SerializeField] UnityEvent onRelease;

    private bool isPressed;
    private Vector3 startingPosition;

}