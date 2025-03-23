using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeverManager : MonoBehaviour
{
    [SerializeField] GameObject weightText;
    private double effortWeight;
    private double resWeight;
    // Start is called before the first frame update
    void Start()
    {
        effortWeight = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEffortWeight(double effWeight) {
        effortWeight = effWeight;
        weightText.GetComponent<TextMeshPro>().text = effWeight.ToString() + " lb";
    }
}
