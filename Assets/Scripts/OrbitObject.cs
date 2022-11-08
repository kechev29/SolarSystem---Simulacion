using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitObject : MonoBehaviour
{
    [SerializeField] float mass;
    [SerializeField] Vector2 startVelocity;

    [Header("Parent")]
    [SerializeField] Transform parentTransform;
    [SerializeField] float parentMass;

    [Header("Debug")]
    [SerializeField] private Vector2 netForce;
    [SerializeField] private Vector2 acceleration;
    [SerializeField] private Vector2 velocity;

    private void Start()
    {
        velocity = startVelocity;
    }

    private void FixedUpdate()
    {
        netForce = new Vector2(0, 0);
        ApplyForce(Gravity());
        Move();
    }

    public void Move()
    {
        //movimiento
        velocity = velocity + Time.fixedDeltaTime * acceleration;

        transform.position = transform.position + Time.fixedDeltaTime * new Vector3(velocity.x, velocity.y, 0f);
    }

    private void ApplyForce(Vector2 force)
    {
        netForce += force;
        acceleration = netForce / mass;
    }

    private Vector2 Gravity()
    {
        Vector2 distanceBetweenObjects = parentTransform.position - transform.position;

        Vector2 gravityResult = ((mass * parentMass) / distanceBetweenObjects.sqrMagnitude) * distanceBetweenObjects.normalized; //G constant not taken into account
        return gravityResult;
    }


}
