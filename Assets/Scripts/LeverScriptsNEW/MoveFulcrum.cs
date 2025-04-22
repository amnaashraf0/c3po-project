using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class MoveFulcrum : MonoBehaviour
{
    [SerializeField] GameObject catapultArm;
    [SerializeField] GameObject fullCatapultObj;
    private float[] fulcrumPositions = { 0.32f, 1.3f, 2, 2.84f, 3.86f };
    private int chosenPosition;
    // Start is called before the first frame update
    void Start()
    {
        chosenPosition = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.x);
    }

    public void setFulcrumPosition(int pos) {
        catapultArm.transform.SetParent(fullCatapultObj.transform);

        // subtract one cause 0 is first index
        chosenPosition = pos - 1;
        transform.localPosition = new Vector3(fulcrumPositions[chosenPosition], transform.localPosition.y, transform.localPosition.z);

        catapultArm.transform.SetParent(this.transform);
    }
}
