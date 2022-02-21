using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOptions : MonoBehaviour
{
    [Header("Attributes of object")]
    public bool isStatic;
    public bool hasDialog;

    [Header("Highlight settings")]
    public bool isPickable;
    Material _DefaultMaterial;
    public Material _GlowMaterial;
    bool isHighlighted;

    [Header("Pickup variables")]
    public Transform thisParent;
    Physics _Physics;

    private void Awake() 
    {
        _DefaultMaterial = this.GetComponent<Renderer>().material;
        thisParent = this.transform.parent;
    }

    private void OnTriggerExit(Collider other) 
    {
        RemoveHighlightObject();
    }

    public void HighlightObject()
    {
        this.GetComponent<Renderer>().material = _GlowMaterial;
    }

    public void RemoveHighlightObject()
    {
        this.GetComponent<Renderer>().material = _DefaultMaterial;
    }
}
