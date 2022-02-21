using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    CharacterNavigationController _CharacterController;
    public Waypoint _CurrentWaypoint;
    int direction;

    private void Awake() 
    {
        _CharacterController = GetComponent<CharacterNavigationController>();
    }

    void Start() 
    {
        direction = Random.Range(1,10);
        _CharacterController.SetDestination(_CurrentWaypoint.GetPosition());    
    }

    void Update() 
    {
        if (_CharacterController.reachedDestination)
        {
            if (direction%2 == 0)
            {
                _CurrentWaypoint = _CurrentWaypoint._NextWaypoint;
            }
            
            if (direction%2 == 1)
            {
                _CurrentWaypoint = _CurrentWaypoint._PreviousWaypoint;
            }
            _CharacterController.SetDestination(_CurrentWaypoint.GetPosition());
        }    
    }
}
