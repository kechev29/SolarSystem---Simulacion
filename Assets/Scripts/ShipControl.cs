using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipControl : MonoBehaviour
{
    Vector3 currentTarget;
    float targetAngle;
    bool isTravellingToTarget;
    MotionControl motion;
    ShipEvents events;
    ShipEngine engineAnim;

    GameObject currentPlanetCamera;

    //[SerializeField] ParallaxBackground parallaxControl;

    private void Awake()
    {
        motion = GetComponent<MotionControl>();
        events = GetComponent<ShipEvents>();
        engineAnim = GetComponent<ShipEngine>();
    }

    void Start()
    {
        targetAngle = 0f;
    }

    void Update()
    {
        motion.RotateZSpeed();

        if(motion.normalizedTime > 0.95f) //interpolation counter used to make sure the ship only starts moving after it rotated towards the target
        {
            if (isTravellingToTarget)
            {
                
                motion.TravelToTarget();
            }
        }
    }

    //looks towards new planet selected - used by the UI logic to tell the ship which one is the new planet
    public void LookAtPosition(Vector3 pos)
    {
        currentTarget = pos;

        Vector3 direction = pos - transform.position;
        motion.SetShipSpeed(direction);

        float angle = Mathf.Atan2(direction.y, direction.x);
        targetAngle = angle * Mathf.Rad2Deg;

        motion.ResetRotationTween(targetAngle);

        isTravellingToTarget = true;
        engineAnim.PlayEngine();

        DisablePlanetCamera();

        //telling observers that the ship is leaving
        events.CallLeavingTarget();
    }

    //checks if the ships arrived at the target planet
    private void CheckTarget(GameObject planetPosition)
    {
        //checks that collision is a planet
        if (planetPosition.GetComponent<Planet>() != null)
        {
            Planet planet = planetPosition.GetComponent<Planet>();

            //checks if the arrived planet is the target one
            if (planetPosition.transform.position == currentTarget)
            {
                //stop the ship
                isTravellingToTarget = false;

                //enable the planet zoom out
                planet.EnablePlanetCamera();
                currentPlanetCamera = planet.ReturnPlanetCamera();

                //invoke arrival events
                events.CallArrivalAtTarget();
                events.CallArrivalAtTargetName(planet.planetInfo);
                engineAnim.KillEngine();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckTarget(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Planet planet = collision.GetComponent<Planet>();
        planet.DisablePlanetCamera();
    }

    public void DisablePlanetCamera()
    {
        if (currentPlanetCamera != null && currentPlanetCamera.activeSelf)
            currentPlanetCamera.SetActive(false);
    }
}
