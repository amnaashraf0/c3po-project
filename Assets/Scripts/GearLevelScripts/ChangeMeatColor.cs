using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
public class ChangeMeatColor : MonoBehaviour
{
    [SerializeField] List<Material> materials;
    [SerializeField] GearManager gm;
    private bool onStove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMeatMaterial() {
        //material[0] = raw material
        //material[1] = cooked material
        //material[2] = burnt material

        double ima = gm.getIMA();
        double correctIma = gm.getCorrectIMA();
        if (onStove)
        {
            if (this.gameObject.GetComponent<MeshRenderer>().material.name.Contains(materials[1].name))
            {
                if (ima > correctIma) { this.gameObject.GetComponent<MeshRenderer>().material = materials[2]; }
            }
            else if (this.gameObject.GetComponent<MeshRenderer>().material.name.Contains(materials[0].name))
            {
                if (ima > correctIma) { this.gameObject.GetComponent<MeshRenderer>().material = materials[2]; }

                else if (ima == correctIma) { this.gameObject.GetComponent<MeshRenderer>().material = materials[1]; }

            }
        }
    }

    public void setOnStoveTrue() {
        onStove = true;
        setMeatMaterial();
    }

    public void setOnStoveFalse() { onStove = false; }
}
