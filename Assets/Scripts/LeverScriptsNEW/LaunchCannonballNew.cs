using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCannonballNew : MonoBehaviour
{
    private QuadraticCurve curve;
    public float speed;
    public bool done = false;
    [SerializeField] LeverManageNew leverManager;

    private float sampleTime;
    void Start()
    {
        sampleTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            sampleTime += Time.deltaTime * speed;
            transform.position = curve.evaluate(sampleTime);
            transform.forward = curve.evaluate(sampleTime + 0.001f) - transform.position;

            if (sampleTime >= 1f)
            {
                //Debug.Log("done");
                leverManager.doneLaunching = true;
            }
        }
    }

    public void setCurve(QuadraticCurve givenCurve) { curve = givenCurve; }
    public void resetTime() { sampleTime = 0f; }
}
