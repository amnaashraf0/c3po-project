using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearCollider : MonoBehaviour
{
    // Start is called before the first frame update
    Boolean isColliding = false;
    String colliding = "";

   void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Gear") || collision.gameObject.name.Contains("stove"))
        {
            colliding = collision.gameObject.name;
            isColliding = true;
        }
        else {
            isColliding = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("Gear") || collision.gameObject.name.Contains("stove")) {
            isColliding = true;
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
