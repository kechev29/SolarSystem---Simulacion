using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(Vector2 deltaMovement);
    public ParallaxCameraDelegate onCameraTranslate;
    private Vector2 oldPosition;
    void Start()
    {
        oldPosition = transform.position;
    }
    void Update()
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);

        if (currentPos != oldPosition)
        {
            if (onCameraTranslate != null)
            {
                Vector2 delta = oldPosition - currentPos;
                onCameraTranslate(delta);
            }
            oldPosition = currentPos;
        }
    }
}
