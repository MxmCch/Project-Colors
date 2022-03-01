using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNavigationController : MonoBehaviour
{
    public Vector3 destination;
    Vector3 lastPosition;
    public bool reachedDestination;
    public float stopDistance = 1;
    public float rotationSpeed = 5;
    public float movementSpeed;
    public float isTalking;
    Vector3 velocity;
    
    private void Start()
    {
        isTalking = 1;
        movementSpeed = Random.Range(4, 8);
    }

    private void Update() 
    {
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopDistance)
            {
                reachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * isTalking);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime * isTalking);
            }
            else
            {
                reachedDestination = true;
            }

            velocity = (transform.position - lastPosition) / Time.deltaTime;
            velocity.y = 0;
            var velocityMagnitude = velocity.magnitude;
            velocity = velocity.normalized;
            var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
            var rightDotProduct = Vector3.Dot(transform.right, velocity);
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        reachedDestination = false;
    }
}
