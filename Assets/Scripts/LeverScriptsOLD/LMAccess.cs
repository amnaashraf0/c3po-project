using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMAccess : MonoBehaviour
{
    public LeverManager LM;

    private void launchCannonball() {
        LM.launchCannonBall();
    }
}
