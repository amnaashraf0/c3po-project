using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearCollider : MonoBehaviour
{
    // Start is called before the first frame update
    Boolean isColliding = false;
    String colliding = "";
    
    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
        if (collision.gameObject.name.Contains("Gear"))
        {
           // Debug.Log("COLLISION ENTER!!!!!! " + collision.gameObject.name);
           colliding = collision.gameObject.name;
        }
        else {
            //Debug.Log("COLLISION ENTER!!!!!! " + collision.gameObject.name);
            colliding = collision.gameObject.name;
        }
    }

    
    private void OnCollisionStay(Collision collision)
    {
        isColliding = true;
        if (collision.gameObject.name.Contains("Gear"))
        {
            //Debug.Log("COLLISION STAY!!!!!! " + collision.gameObject.name);
            colliding = collision.gameObject.name;
        }
        else {
            //Debug.Log("COLLISION STAY!!!!!! " + collision.gameObject.name);
            colliding = collision.gameObject.name;
        }
    }
    


    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
        colliding = collision.gameObject.name;
    }

    public Boolean getColliding() { return isColliding; }

    public String getCollidingString() { return colliding; }
}
