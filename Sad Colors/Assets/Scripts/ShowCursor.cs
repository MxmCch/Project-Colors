using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    public GameObject cameraMovement;
    float defaultCameraMovement;
    CameraMove _CameraMove;
    
    private void Awake() 
    {
        _CameraMove = cameraMovement.GetComponent<CameraMove>(); 
        defaultCameraMovement = _CameraMove.mouseSensitivity;
    }

    private void OnEnable() 
    {
        _CameraMove.mouseSensitivity = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDisable() 
    {
        Cursor.visible = false;
        _CameraMove.mouseSensitivity = defaultCameraMovement;
    }
}
