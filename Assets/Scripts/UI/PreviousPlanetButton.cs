using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousPlanetButton : MonoBehaviour
{
    [SerializeField] MapPlanetLogic mapLogic;
    Button buttonComponent;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();

        ShipEvents.arrivalAtTarget += EnableButton;
        ShipEvents.leavingTarget += DisableButton;
    }


    public void ButtonPreviousPlanet()
    {
        mapLogic.ReturnToPreviousPlanet();
    }

    private void DisableButton()
    {
        buttonComponent.interactable = false;
    }

    private void EnableButton()
    {
        buttonComponent.interactable = true;
    }
}
