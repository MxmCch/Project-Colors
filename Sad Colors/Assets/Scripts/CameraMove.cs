using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    float xRotation = 0f;


    void Start()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f, 90f);


        Quaternion targetRotation = Quaternion.Euler(xRotation,0f,0f);
        transform.localRotation = Quaternion.Slerp(this.transform.localRotation,targetRotation, mouseSensitivity *  Time.deltaTime);
        
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
