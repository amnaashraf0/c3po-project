using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballProperties : MonoBehaviour
{
    [SerializeField] double weight;

    public double getWeight() { return weight; }
}
