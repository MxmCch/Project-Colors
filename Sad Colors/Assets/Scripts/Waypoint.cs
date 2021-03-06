using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint _PreviousWaypoint;
    public Waypoint _NextWaypoint;


    [Range(0f, 10f)]
    public float width = 1f;

    public Vector3 GetPosition()
    {
        Vector3 minBound = transform.position + transform.right * width/2;
        Vector3 maxBound = transform.position - transform.right * width/2;

        return Vector3.Lerp(minBound,maxBound, Random.Range(0f, 1f));
        
    }
    
}
