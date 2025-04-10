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
        //Debug.Log(transform.localEulerAngles.z);
        if (transform.localEulerAngles.z > 300 && transform.localEulerAngles.z < 320) {
            Debug.Log("Lever pulled");
        }
    }
}
