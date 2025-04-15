using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPulled : MonoBehaviour
{
    private bool leverPulled = false;

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(transform.localEulerAngles.z);
        if (transform.localEulerAngles.z > 300 && transform.localEulerAngles.z < 320)
        {
            //Debug.Log("Lever pulled");
            leverPulled = true;
        }
        else {
            leverPulled = false;
            //Debug.Log("Lever not pulled");
        }
    }

    public bool isLeverPulled() { return leverPulled; }
}
