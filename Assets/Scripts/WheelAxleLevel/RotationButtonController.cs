using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationButtonController : MonoBehaviour
{
    [SerializeField] XRSocketInteractor wheelSocket;
    [SerializeField] RotateAround rotateScript;
    [SerializeField] Button rotateButton;

    void Start()
    {
        rotateButton.onClick.AddListener(() => {
            bool hasWheel = wheelSocket.GetOldestInteractableSelected() != null;
            rotateScript.enabled = hasWheel;
        });
    }
}

/*void Start()
{
    // Link the button click to ToggleRotation
    rotateButton.onClick.AddListener(ToggleRotation);
}

private void ToggleRotation()
{
    // Only enable rotation if there's a wheel in the socket
    IXRSelectInteractable wheelInSocket = wheelSocket.GetOldestInteractableSelected();
    rotateScript.enabled = (wheelInSocket != null);
}

*/