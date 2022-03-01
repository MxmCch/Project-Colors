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
    public Material[] _DefaultMaterials;
    public Material _GlowMaterial;
    bool isHighlighted;

    [Header("Pickup variables")]
    public Transform thisParent;
    Physics _Physics;

    private void Awake() 
    {
        _DefaultMaterials = new Material[transform.childCount];
        
        int x = 0;
        foreach (Transform item in transform)
        {
            _DefaultMaterials[x] = item.GetComponent<Renderer>().material;
            x++;
        }
        thisParent = this.transform.parent;
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            RemoveHighlightObject();
        }
    }

    public void HighlightObject()
    {
        foreach (Transform item in this.transform)
        {
            item.GetComponent<Renderer>().material = _GlowMaterial;
        }
    }

    public void RemoveHighlightObject()
    {
        int x = 0;
        foreach (Transform item in transform)
        {
            item.GetComponent<Renderer>().material = _DefaultMaterials[x];
            x++;
        }
    }
}
