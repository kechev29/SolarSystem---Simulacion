using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipEvents : MonoBehaviour
{
    //EVENTS
    public static event Action arrivalAtTarget;
    public static event Action leavingTarget;
    public static event Action<string> arrivalAtTargetName;

    public void CallArrivalAtTarget()
    {
        arrivalAtTarget?.Invoke();
    }

    public void CallLeavingTarget()
    {
        leavingTarget?.Invoke();
    }

    public void CallArrivalAtTargetName(string target)
    {
        arrivalAtTargetName?.Invoke(target);
    }

}
