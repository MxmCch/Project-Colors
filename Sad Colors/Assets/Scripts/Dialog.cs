using System;
using UnityEngine;

public class Dialog : MonoBehaviour
{   
    [Serializable]
    public struct DialogText
    {
        public string NPCDialogName;
        public string[] TextDialog;
        public GameObject[] ChoiceObjects;
        public string finalChoice;
    }
    
    [SerializeField]
    public int ThisSkipDialog;
    public DialogText[] DialogArray;
}
