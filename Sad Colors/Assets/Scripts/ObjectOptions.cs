using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOptions : MonoBehaviour
{
    [Header("Attributes of object")]
    public bool isStatic;
    public bool hasDialog;
    public bool hasChildren = false;
    public bool dissappear = false;

    [Header("Highlight settings")]
    public bool isPickable;
    Material[] _DefaultMaterials;
    Transform[] _ChildrenTransforms;
    public Material _GlowMaterial;
    Material _SingleMaterial;
    bool isHighlighted;

    [Header("Pickup variables")]
    public Transform thisParent;
    Physics _Physics;

    [SerializeField]
    CollectAllToys _CollectAllToys;

    private void OnDisable() 
    {
        if(dissappear)
        {
            _CollectAllToys.CheckToys();
        }
    }

    private void Awake() 
    {
        _DefaultMaterials = new Material[transform.childCount];
        
        int x = 0;
        if (hasChildren)
        {
            foreach (Transform item in transform)
            {
                _DefaultMaterials[x] = item.GetComponent<Renderer>().material;
                x++;
            }
        }
        else
        {
            _SingleMaterial = this.GetComponent<Renderer>().material;
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
        if (hasChildren)
        {
            foreach (Transform item in this.transform)
            {
                item.GetComponent<Renderer>().material = _GlowMaterial;
            }
        }
        else
        {
            this.GetComponent<Renderer>().material = _GlowMaterial;
        }
    }

    public void RemoveHighlightObject()
    {
        int x = 0;
        
        if (hasChildren)
        {
            foreach (Transform item in this.transform)
            {
                item.GetComponent<Renderer>().material = _DefaultMaterials[x];
                x++;
            }
        }
        else
        {
            this.GetComponent<Renderer>().material = _SingleMaterial;
        }
    }
}
