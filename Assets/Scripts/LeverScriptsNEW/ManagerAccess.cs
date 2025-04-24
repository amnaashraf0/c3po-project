using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAccess : MonoBehaviour
{
    [SerializeField] LeverManageNew lm;

    public void launchCannonball() {
        lm.launchCannonBall();
    }
}
