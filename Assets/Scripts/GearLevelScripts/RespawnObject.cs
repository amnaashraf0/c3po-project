using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RespawnObject : MonoBehaviour
{
    private Vector3 startingPosition;
    private Quaternion startingRotation;

    public static float respawnYThreshold = -0.5f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;
        startingRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.localPosition.y);
        if (transform.localPosition.y < respawnYThreshold)
        {
            resetPosition();
        }
    }

    public void resetPosition() {
        transform.localPosition = startingPosition;
        transform.localRotation = startingRotation;
    }
}
