using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapSelectionUI : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    [SerializeField] Button mapButton;
    [SerializeField] RectTransform crosshairImage;
    RectTransform newPosition;

    private void Awake()
    {
        ShipEvents.arrivalAtTarget += EnableMap;
        ShipEvents.leavingTarget += DisableMap;

        //add event for when the spaceship arrives, enable planet buttons + map button
    }

    public void DisablePlanetButtons()
    {
        if (buttons == null) Debug.Log("Buttons null");
        else
        {
            buttons.SetActive(false);
        }
    }
    public void EnablePlanetButtons()
    {
        buttons.SetActive(true);
    }

    private void DisableMapButton()
    {
        mapButton.interactable = false;
    }
    private void EnableMapButton()
    {
        mapButton.interactable = true;
    }

    private void EnableMap()
    {
        EnableMapButton();
        EnablePlanetButtons();
    }
    private void DisableMap()
    {
        DisablePlanetButtons();
        DisableMapButton();
    }

    public void SetNewPosition(RectTransform newPos)
    {
        newPosition = newPos;
        SetImagePosition();
        DisablePlanetButtons();
        DisableMapButton();
    }

    //CROSSHAIR
    private void SetImagePosition()
    {
        if (crosshairImage == null) Debug.Log("Crosshair null");
        else
        {
            //Debug.Log(newPosition.anchoredPosition);
            crosshairImage.anchoredPosition = newPosition.anchoredPosition;
            crosshairImage.sizeDelta = newPosition.sizeDelta;
        }
    }
}
