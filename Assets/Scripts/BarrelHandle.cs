using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Enables natural hand-controlled rotation of a VR handle
/// Works with XR Interaction Toolkit (Unity 2022.3+)
/// </summary>
[RequireComponent(typeof(XRGrabInteractable))]
public class VRHandleRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Local axis to rotate around (typically Y for horizontal handles, Z for vertical)")]
    public Vector3 rotationAxis = Vector3.up;

    [Tooltip("Rotation speed multiplier (degrees per unit of hand movement)")]
    [Range(50, 500)]
    public float rotationSensitivity = 200f;

    // Internal tracking
    private XRGrabInteractable _grabInteractable;
    private Vector3 _lastControllerPosition;
    private bool _isGrabbed = false;

    void Awake()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();

        // Set up grab events
        _grabInteractable.selectEntered.AddListener(HandleGrabbed);
        _grabInteractable.selectExited.AddListener(HandleReleased);
    }

    void Update()
    {
        if (_isGrabbed && _grabInteractable.isSelected)
        {
            RotateBasedOnControllerMovement();
        }
    }

    /// <summary>
    /// Calculates rotation based on controller/hand movement
    /// </summary>
    private void RotateBasedOnControllerMovement()
    {
        // 1. Get current controller position in world space
        Vector3 currentPos = _grabInteractable.firstInteractorSelecting.transform.position;

        // 2. Calculate movement vector since last frame
        Vector3 movementDelta = currentPos - _lastControllerPosition;

        // 3. Project movement onto rotation axis to get rotational component
        float rotationDegrees = Vector3.Dot(movementDelta, transform.TransformDirection(rotationAxis))
                             * rotationSensitivity;

        // 4. Apply rotation locally around the specified axis
        transform.Rotate(rotationAxis, rotationDegrees, Space.Self);

        // 5. Update position reference for next frame
        _lastControllerPosition = currentPos;
    }

    /// <summary>
    /// Called when handle is grabbed by a controller/hand
    /// </summary>
    private void HandleGrabbed(SelectEnterEventArgs args)
    {
        _isGrabbed = true;
        _lastControllerPosition = args.interactorObject.transform.position;
    }

    /// <summary>
    /// Called when handle is released
    /// </summary>
    private void HandleReleased(SelectExitEventArgs args)
    {
        _isGrabbed = false;
    }

    void OnDestroy()
    {
        // Clean up event listeners
        if (_grabInteractable != null)
        {
            _grabInteractable.selectEntered.RemoveListener(HandleGrabbed);
            _grabInteractable.selectExited.RemoveListener(HandleReleased);
        }
    }
}
