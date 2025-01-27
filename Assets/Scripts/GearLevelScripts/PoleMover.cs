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
    private float speed = 0.1f;
    private int counter = 0;
    void Start()
    {
        startingPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        gearCount = gearManager.getGearCount();
        if (gearCount <= 4 && counter <= 100) {
            IXRSelectInteractable interactable = interactor.GetOldestInteractableSelected();
            GameObject gear = interactable.transform.gameObject;
            bool isColliding = gear.GetComponent<gearCollider>().getColliding();
            string collidingString = gear.GetComponent<gearCollider>().getCollidingString();
            Debug.Log(isColliding + " " + collidingString);
            //Debug.Log(isColliding);
            /*
            while (gear.GetComponent<gearCollider>().getColliding() == false) {
                this.transform.localPosition = -Vector3.forward * speed * Time.deltaTime;
                counter++;
                if (counter == 100)
                    break;
            }
            */
        }
    }
}
