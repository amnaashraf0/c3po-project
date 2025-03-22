using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanCollider : MonoBehaviour
{
    [SerializeField] GameObject meat;
    [SerializeField] Material raw;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null) {
            if (collision.gameObject.name.Contains("Meat"))
            {
                meat.gameObject.GetComponent<MeshRenderer>().material = raw;
                meat.gameObject.GetComponent<RespawnObject>().resetPosition();
            }
        }
    }
}
