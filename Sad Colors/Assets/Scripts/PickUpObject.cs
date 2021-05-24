using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public float pickUpRange = 5;
    private GameObject heldObj;
    public Transform holdParent;
    public float moveForce = 250;
    public Color oldColor;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Pickupable")
        {
            oldColor = other.GetComponent<Renderer>().material.color;
            Renderer colorComponent = other.GetComponent<Renderer>();
            colorComponent.material.SetColor("_Color", Color.green);
            colorComponent.material.EnableKeyword("_EMISSION");
            colorComponent.material.SetColor("_EmissionColor", Color.green * 1.8f);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Pickupable")
        {
            other.GetComponent<Renderer>().material.SetColor("_Color", oldColor);
            other.GetComponent<Renderer>().material.SetColor("_EmissionColor", oldColor/ 1.8f);
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange) && hit.transform.tag == "Pickupable")
                {
                    PickupObject(hit.transform.gameObject);
                    
                }
            }else{
                DropObject();
            }
        }
        if (heldObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            pickObj.GetComponent<Renderer>().material.SetColor("_Color", oldColor);
            pickObj.GetComponent<Renderer>().material.SetColor("_Emission", oldColor/1.8f);
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 20;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldRig.transform.parent = null;
        heldObj = null;
    }
}
