using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour
{
    [System.NonSerialized] public float normalizedTime;
    [SerializeField] float startingSpeed;
    [SerializeField] float rotationDuration;
    [SerializeField] AnimationCurve rotationTweenSpeed;

    float movementSpeed;
    float currentTime;

    float initialRotation;
    float finalRotation;

    //interpolates the rotation between the starting rotation and the rotation towards target planet
    public void RotateZSpeed()
    {
        normalizedTime = currentTime / rotationDuration;
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0f, 0f, initialRotation), Quaternion.Euler(0f, 0f, finalRotation), rotationTweenSpeed.Evaluate(normalizedTime));
        currentTime += Time.deltaTime;
    }

    //resets values for the rotation tween
    public void ResetRotationTween(float targetAngle)
    {
        currentTime = 0;
        initialRotation = transform.rotation.eulerAngles.z;
        finalRotation = targetAngle;
    }

    //sets the ship speed depending on the distance from the target
    public void SetShipSpeed(Vector3 direction)
    {
        float distance = direction.sqrMagnitude;

        if (distance <= 3000) movementSpeed = startingSpeed;
        else if (distance < 5000) movementSpeed = startingSpeed * 2;
        else movementSpeed = startingSpeed * 3;
    }

    //moves forward at an uniform speed
    public void TravelToTarget()
    {
        transform.position += movementSpeed * Time.deltaTime * transform.right;
    }

}
