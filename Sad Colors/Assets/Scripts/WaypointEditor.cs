using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor : MonoBehaviour
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawGizmos(Waypoint waypoint, GizmoType gizmoType) 
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.yellow * 0.5f;
        }
        Gizmos.DrawSphere(waypoint.transform.position, .1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.width / 2),
        waypoint.transform.position - (waypoint.transform.right * waypoint.width/2f));

        if (waypoint._PreviousWaypoint != null) 
        {
            Gizmos.color = Color.red;
            Vector3 offset = waypoint.transform.right * waypoint.width / 2f;
            Vector3 offsetTo = waypoint._PreviousWaypoint.transform.right * waypoint._PreviousWaypoint.width / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint._PreviousWaypoint.transform.position + offsetTo);
        }

        if (waypoint._NextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Vector3 offset = waypoint.transform.right * -waypoint.width / 2f;
            Vector3 offsetTo = waypoint._NextWaypoint.transform.right * -waypoint._NextWaypoint.width / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint._NextWaypoint.transform.position + offsetTo);
        }
    }
}
