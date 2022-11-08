using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSetActive : MonoBehaviour
{
    
    public void ToggleSetActive()
    {
        gameObject.SetActive(false);
    }

    public void ToggleSetActivePlanets()
    {
        transform.parent.GetChild(1).gameObject.SetActive(false);
        transform.parent.GetChild(2).gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ToggleSetActiveMap()
    {
        transform.parent.gameObject.SetActive(false);
    }

}
