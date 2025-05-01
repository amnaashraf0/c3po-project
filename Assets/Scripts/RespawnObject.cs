using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RespawnObject : MonoBehaviour
{
    private Vector3 startingPosition;
    private Quaternion startingRotation;

    public static float respawnYThreshold = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.y);
        if (transform.position.y < respawnYThreshold && !this.gameObject.name.Contains("Slime"))
        {
            resetPosition();
        }
    }

    public void resetPosition() {
        transform.position = startingPosition;
        transform.localRotation = startingRotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
