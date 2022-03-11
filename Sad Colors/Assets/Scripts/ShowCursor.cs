using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    public GameObject cameraMovement;
    float defaultCameraMovement;
    CameraMove _CameraMove;
    [SerializeField]
    PlayerMovement _PlayerMovement;
    [SerializeField]
    bool isTrue = true;
    
    private void Awake() 
    {
        if (isTrue)
        {
            _CameraMove = cameraMovement.GetComponent<CameraMove>(); 
            defaultCameraMovement = _CameraMove.mouseSensitivity;
        }
    }

    private void OnEnable() 
    {
        if (isTrue)
        {
            _PlayerMovement.speed = 0;
            _CameraMove.mouseSensitivity = 0;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDisable() 
    {
        _PlayerMovement.speed = 6;
        _CameraMove.mouseSensitivity = defaultCameraMovement;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
