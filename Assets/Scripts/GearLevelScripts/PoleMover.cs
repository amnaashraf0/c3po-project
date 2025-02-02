using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PoleMover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GearManager gearManager;
    [SerializeField] XRSocketInteractor interactor;
    private int gearCount = 0;
    private Vector3 startingPosition;
    private float speed = 0.01f;
    GameObject connectedGear = null;
    private bool hasMoved = false;
    private Material cantHoverMaterial = null;
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gearCount = gearManager.getGearCount();
        if (gearCount == 4)
        {
            hasMoved = true;
            IXRSelectInteractable interactable = interactor.GetOldestInteractableSelected();
            connectedGear = interactable.transform.gameObject;
            connectedGear.GetComponent<Rigidbody>().isKinematic = false;
            bool isColliding = connectedGear.GetComponent<gearCollider>().getColliding();


            if (isColliding == false)
            {
                Vector3 position = transform.position;
                this.transform.position = new Vector3(position.x, position.y, position.z - speed);
                cantHoverMaterial = interactor.interactableCantHoverMeshMaterial;
            }
            if (isColliding == true) {
                interactor.interactableCantHoverMeshMaterial = null;
            }
        }
        else {
            if (hasMoved == true) {
                transform.position = startingPosition;
                hasMoved = false;
                interactor.interactableCantHoverMeshMaterial = cantHoverMaterial;
            }
        }
    }
}
