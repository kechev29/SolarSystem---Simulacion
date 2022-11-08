using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButtons : MonoBehaviour
{
    [SerializeField] MapPlanetLogic map;
    MapSelectionUI uiInputControl;
    RectTransform rectTrans;
    string planet;

    bool validSelection;

    void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        planet = gameObject.name;
        uiInputControl = GetComponentInParent<MapSelectionUI>();
    }

    private void ReturnName()
    {
        map.NewLocation(planet, true);
    }

    public void ButtonAction()
    {
        ReturnName();
        if (map.ValidateSelection())
        {
            uiInputControl.SetNewPosition(rectTrans);
        }
        
    }


}
