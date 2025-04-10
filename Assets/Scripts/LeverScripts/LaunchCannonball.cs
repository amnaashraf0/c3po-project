using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCannonball : MonoBehaviour
{
    public QuadraticCurve curve;
    public float speed;
    public bool done = false;
    [SerializeField] LeverManager leverManager;

    private float sampleTime;
    void Start()
    {
        sampleTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        sampleTime += Time.deltaTime * speed;
        transform.position = curve.evaluate(sampleTime);
        transform.forward = curve.evaluate(sampleTime + 0.001f) - transform.position;

        if (sampleTime >= 1f) {
            //Debug.Log("done");
            leverManager.doneLaunching = true;
        }
    }
}
