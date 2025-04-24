using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateAround : MonoBehaviour
{
    public Transform pivotPoint;
    public float rotationSpeed = 10.0f;

    void Start() => enabled = false;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(pivotPoint.position, pivotPoint.transform.up //supposedly uses the pivot's current orientation
            , rotationSpeed * Time.deltaTime);
        
    }
}

//transform.RotateAround(pivotPoint.position, Vector3.forward, rotationSpeed * Time.deltaTime);


// Vector3 pivotToObject = transform.position - pivotPoint.position;
// transform.position = pivotPoint + Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime); * pivotToObject;
