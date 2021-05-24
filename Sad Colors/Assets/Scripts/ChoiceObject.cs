using UnityEngine;

public class ChoiceObject : MonoBehaviour
{
    public Color oldColor;
    public Renderer newColor;
    public Transform rodic;
    ChoiceArchive _ChoiceArchive;
    Dialog _Dialog;
    Interact _Interact;
    bool inside;

    public void OnMouseUp() 
    {
        if (inside)
        {
            rodic = this.transform.parent;
            _Dialog = this.gameObject.GetComponentInParent<Dialog>();

            foreach (Transform item in rodic)
            {
                if (item == this.transform)
                {
                    int getNewDialog = _Interact.NextPersonDialog;
                    int CurrentStop = _Interact.CurrentStop;
                    _Interact.SkipDialog = CurrentStop+1;
                    _Dialog.ThisSkipDialog = CurrentStop+1;
                    Debug.Log(item.name);
                    _Dialog.DialogArray[CurrentStop].finalChoice = item.name; 
                    Destroy(item.gameObject, 2);
                    _Interact.DecisionActive = false;
                }
                else
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        oldColor = this.GetComponent<Renderer>().material.color;
        newColor = this.GetComponent<Renderer>();
        newColor.material.SetColor("_Color", Color.green);
        _ChoiceArchive = other.gameObject.GetComponent<ChoiceArchive>();
        _Interact = other.gameObject.GetComponent<Interact>();
        inside = true;
    }

    void OnTriggerExit(Collider other) {
        newColor.material.SetColor("_Color", oldColor);
        inside = false;
    }
}