using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitedPlanets : MonoBehaviour
{
    Stack<string> visitedPlanets = new Stack<string>();

    public void AddToList(string planetName)
    {
        visitedPlanets.Push(planetName);
        //Debug.Log("stack count: " + visitedPlanets.Count);
    }

    public string GetLastPlanet()
    {
        if (visitedPlanets.Count > 0) return visitedPlanets.Pop();
        else return null;
    }

    public string CheckLastPlanet()
    {
        if (visitedPlanets.Count > 0) return visitedPlanets.Peek();
        else return null;
    }

}
