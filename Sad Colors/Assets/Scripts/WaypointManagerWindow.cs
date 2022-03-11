using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/*

public class WaypointManagerWindow : EditorWindow
{
    [MenuItem("Tools/Waypoint Editor")]
    public static void Open()
    {
        GetWindow<WaypointManagerWindow>();
    }

    public Transform waypointRoot;

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));

        if(waypointRoot == null)
        {
            EditorGUILayout.HelpBox("Root transform must be selected", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();
    }

    void DrawButtons()
    {
        if (GUILayout.Button("Create Waypoint"))
        {
            CreateWaypoint();
        }
        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Waypoint>())
        {
            if (GUILayout.Button("Create Waypoint Before"))
            {
                CreateNewBefore();
            }
            if (GUILayout.Button("Create Waypoint After"))
            {
                CreateNewAfter();
            }
            if (GUILayout.Button("Remove Waypoint"))
            {
                RemoveWaypoint();
            }
        }
    }


    void CreateWaypoint()
    {
        GameObject waypointObject = new GameObject("Waypoint" + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);

        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
        if (waypointRoot.childCount > 1)
        {
            waypoint._PreviousWaypoint = waypointRoot.GetChild(waypointRoot.childCount - 2).GetComponent<Waypoint>(); 
            waypoint._PreviousWaypoint._NextWaypoint = waypoint;  

            waypoint.transform.position = waypoint._PreviousWaypoint.transform.position; 
            waypoint.transform.forward = waypoint._PreviousWaypoint.transform.forward; 
        }
        Selection.activeGameObject = waypoint.gameObject;
    }

    
    void CreateNewBefore()
    {
        GameObject waypointObject = new GameObject("Waypoint " + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);

        Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();
        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;

        if (selectedWaypoint._PreviousWaypoint != null)
        {
            newWaypoint._PreviousWaypoint = selectedWaypoint._PreviousWaypoint;
            selectedWaypoint._PreviousWaypoint._NextWaypoint = newWaypoint;
        }

        newWaypoint._NextWaypoint = selectedWaypoint;

        selectedWaypoint._PreviousWaypoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newWaypoint.gameObject;

        
    }
    
    void CreateNewAfter()
    {
        GameObject waypointObject = new GameObject("Waypoint " + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);

        Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();
        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;

        newWaypoint._PreviousWaypoint = selectedWaypoint;

        if (selectedWaypoint._NextWaypoint != null)
        {
            selectedWaypoint._NextWaypoint._PreviousWaypoint = newWaypoint;
            newWaypoint._NextWaypoint = selectedWaypoint._NextWaypoint;
        }

        selectedWaypoint._NextWaypoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newWaypoint.gameObject;
    }
    
    void RemoveWaypoint()
    {
        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        if (selectedWaypoint._NextWaypoint != null)
        {
            selectedWaypoint._NextWaypoint._PreviousWaypoint = selectedWaypoint._PreviousWaypoint;
        }
        if (selectedWaypoint._PreviousWaypoint != null)
        {
            selectedWaypoint._PreviousWaypoint._NextWaypoint = selectedWaypoint._NextWaypoint;
            Selection.activeGameObject = selectedWaypoint._PreviousWaypoint.gameObject;
        }

        DestroyImmediate(selectedWaypoint.gameObject);
    }
}
*/