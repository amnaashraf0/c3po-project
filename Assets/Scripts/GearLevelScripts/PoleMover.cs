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
            //get the attached gear and check if the gear is colliding 
            hasMoved = true;
            IXRSelectInteractable interactable = interactor.GetOldestInteractableSelected();
            connectedGear = interactable.transform.gameObject;
            connectedGear.GetComponent<Rigidbody>().isKinematic = false;
            bool isColliding = connectedGear.GetComponent<gearCollider>().getColliding();

            //if it is colliding, turn off canthovermeshmaterial, if not, keep moving to the left
            if (isColliding == false)
            {
                Vector3 position = transform.position;
                this.transform.position = new Vector3(position.x, position.y, position.z - speed);
                cantHoverMaterial = interactor.interactableCantHoverMeshMaterial;
            }
            if (isColliding == true)
            {
                interactor.interactableCantHoverMeshMaterial = null;
                //transform.GetChild(0).transform.Rotate(0, 0, 1);
            }
        }
        //check if a gear was removed when the gear train was complete: if yes move to original position
        else {
            if (hasMoved == true) {
                if (transform.position.z < startingPosition.z)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
                }
                else
                {
                    hasMoved = false;
                    interactor.interactableCantHoverMeshMaterial = cantHoverMaterial;
                }
            }
        }
    }
}
