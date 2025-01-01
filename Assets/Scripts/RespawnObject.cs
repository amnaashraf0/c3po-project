using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    private Vector3 startingPosition;
    public static float respawnYThreshold = -0.8f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.localPosition.y);
        if (transform.localPosition.y < respawnYThreshold)
        {
            transform.localPosition = startingPosition;
        }
    }
}
