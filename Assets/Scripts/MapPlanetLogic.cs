using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlanetLogic : MonoBehaviour
{
    [SerializeField] string[] planetNames;
    [SerializeField] Transform[] planetPositions;
    [SerializeField] ShipControl ship;
    VisitedPlanets planetsList;

    string newPlanet;
    bool validSelection;

    //Using a dictionary because it's more convenient when forming links between two concepts (name of the planet + its position)
    Dictionary<string, Vector3> planets = new Dictionary<string, Vector3>();
    
    void Start()
    {
        //Dictionaries aren't serializable in unity so I had to create an array each for the keys and values, and then add them to the dictionary
        for(int i = 0; i < planetNames.Length; i++)
        {
            planets.Add(planetNames[i], planetPositions[i].localPosition);
        }

        planetsList = GetComponent<VisitedPlanets>();
        newPlanet = "Earth";
    }

    //returns the location linked to the name entered
    public void NewLocation(string name, bool addToStack)
    {

        if (name != newPlanet)
        {
            if (addToStack) planetsList.AddToList(newPlanet);

            Vector3 planetLocation = planets[name];

            ship.LookAtPosition(planetLocation);

            newPlanet = name;
            validSelection = true;

        }
        else validSelection = false;

    }

    public void ReturnToPreviousPlanet()
    {
        if (planetsList.CheckLastPlanet() != null) NewLocation(planetsList.GetLastPlanet(), false);
    }

    public bool ValidateSelection()
    {
        return validSelection;
    }
}
