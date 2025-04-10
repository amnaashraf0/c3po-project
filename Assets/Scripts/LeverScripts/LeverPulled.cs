using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPulled : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.localEulerAngles.y);
        if (transform.localRotation.y < -0.15) {
            //Debug.Log("Lever pulled");
        }
    }
}
