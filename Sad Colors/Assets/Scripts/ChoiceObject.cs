using UnityEngine;

public class ChoiceObject : MonoBehaviour
{
    public Color _OldColor;
    public Renderer _NewColor;
    public Transform _Parent;
    ChoiceArchive _ChoiceArchive;
    Dialog _Dialog;
    Interact _Interact;
    bool inside;

    public void OnMouseUp() 
    {
        if (inside)
        {
            _Parent = this.transform.parent;
            _Dialog = this.gameObject.GetComponentInParent<Dialog>();

            foreach (Transform item in _Parent)
            {
                if (item == this.transform)
                {
                    int getNewDialog = _Interact.nextPersonDialog;
                    int CurrentStop = _Interact.currentStop;
                    _Interact.skipDialog = CurrentStop+1;
                    _Dialog.thisSkipDialog = CurrentStop+1;
                    Debug.Log(item.name);
                    _Dialog._DialogArray[CurrentStop].finalAnswer = item.name; 
                    Destroy(item.gameObject, 2);
                    _Interact.decisionActive = false;
                }
                else
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        _OldColor = this.GetComponent<Renderer>().material.color;
        _NewColor = this.GetComponent<Renderer>();
        _NewColor.material.SetColor("_Color", Color.green);
        _ChoiceArchive = other.gameObject.GetComponent<ChoiceArchive>();
        _Interact = other.gameObject.GetComponent<Interact>();
        inside = true;
    }

    void OnTriggerExit(Collider other) {
        _NewColor.material.SetColor("_Color", _OldColor);
        inside = false;
    }
}