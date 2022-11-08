using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] GameObject planetCamera;
    [TextArea(15, 20)]
    [SerializeField] public string planetInfo;

    public void EnablePlanetCamera()
    {
        if (!planetCamera.activeSelf)
            planetCamera.SetActive(true);
    }

    public void DisablePlanetCamera()
    {
        if(planetCamera.activeSelf)
        planetCamera.SetActive(false);
    }

    public GameObject ReturnPlanetCamera()
    {
        return planetCamera;
    }

}
