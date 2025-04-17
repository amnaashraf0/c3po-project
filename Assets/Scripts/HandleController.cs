using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleController : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 2f;
    public Axis rotationAxis = Axis.Y;
    public bool isCorrectIMA = false;

    [Header("Effects")]
    public ParticleSystem successEffect;
    public ParticleSystem spillEffect;

    private XRGrabInteractable _grabInteractable;
    private Vector3 _lastControllerPosition;
    private bool _isBeingRotated;

    void Start()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _grabInteractable.selectEntered.AddListener(StartRotate);
        _grabInteractable.selectExited.AddListener(StopRotate);
    }

    void Update()
    {
        if (_isBeingRotated && _grabInteractable.isSelected)
        {
            Vector3 currentPos = _grabInteractable.GetOldestInteractorSelecting().transform.position;
            Vector3 delta = currentPos - _lastControllerPosition;
            float rotationAmount = Vector3.Dot(delta, transform.up) * rotationSpeed * Time.deltaTime;

            transform.Rotate(GetRotationAxis() * rotationAmount * Mathf.Rad2Deg, Space.Self);
            _lastControllerPosition = currentPos;
        }
    }

    Vector3 GetRotationAxis()
    {
        return rotationAxis switch
        {
            Axis.X => transform.right,
            Axis.Y => transform.up,
            Axis.Z => transform.forward,
            _ => Vector3.up
        };
    }

    void StartRotate(SelectEnterEventArgs args)
    {
        _isBeingRotated = true;
        _lastControllerPosition = args.interactorObject.transform.position;
    }

    void StopRotate(SelectExitEventArgs args)
    {
        _isBeingRotated = false;
        if (!isCorrectIMA) spillEffect.Play();
        else successEffect.Play();
    }
}

public enum Axis { X, Y, Z }
