using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public float pickUpRange = 5;
    public GameObject heldObj;
    public Transform holdParent;
    public GameObject playerCollider;
    public float moveForce = 300;
    public Color _OldColor;

    public Transform oldParent;
    
    [SerializeField]
    CollectAllToys _CollectAllToys;

// ja nevim 
    private void OnTriggerStay(Collider other) {
        if (other.tag == "Pickupable")
        {
            if (!Input.GetMouseButton(0))
            {
                heldObj = other.gameObject;
                heldObj.GetComponent<ObjectOptions>().HighlightObject();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Pickupable")
        {
            heldObj.GetComponent<ObjectOptions>().RemoveHighlightObject();
            if (!Input.GetMouseButton(0))
            {
                heldObj = null;
            }
        }
    }

    private void FixedUpdate() {
        if(Input.GetMouseButtonDown(0))
        {
            if (heldObj != null && heldObj.GetComponent<ObjectOptions>().dissappear)
            {
                heldObj.gameObject.SetActive(false);
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (heldObj != null)
            {
                heldObj.GetComponent<ObjectOptions>().RemoveHighlightObject();
                MoveObject();
                PickupObject(heldObj);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (heldObj != null)
            {
                DropObject();
            }
            heldObj = null;
        }
    }


    private void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.05f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    private void PickupObject(GameObject pickObj)
    {
        Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
        objRig.useGravity = false;
        objRig.drag = 18;
        heldObj = pickObj;
        pickObj.transform.parent = holdParent;
    }

    private void DropObject()
    {
        heldObj.GetComponent<ObjectOptions>().RemoveHighlightObject();
        heldObj.GetComponent<Collider>().enabled = true;
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.parent = heldObj.GetComponent<ObjectOptions>().thisParent;
        heldObj = null;
    }
}
