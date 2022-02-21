using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Dialog : MonoBehaviour
{   
    public DialogText[] _DialogArray;
    public int thisSkipDialog;
    public int thisEndDialog;
    public bool finishedDialog;

    [Serializable]
    public class DialogText
    {
        static DialogText instance = new DialogText();
        [Tooltip("Name of character who is going to be talking.")]
        public string talkingPersonName;
        
        // test dialog nesmi mit prazdne inputy, jinak error, ktery ale nejde videt ve hre pouze v konzoli
        [Tooltip("Character's dialog, what they are going to say.")]
        public MonologDialogClass[] MonologDialog;

        public DialogAnswerClass[] DialogAnswer;
        public string finalAnswer;
    }

    [Serializable]
    public class DialogAnswerClass
    {
        [Tooltip("Players answer.")]
        public string dialogAnswer;
        [Tooltip("Yellow Color.")]
        public int hope;
        [Tooltip("Green Color.")]
        public int curiosity;
        [Tooltip("Blue Color.")]
        public int unbelief;
        [Tooltip("Red Color.")]
        public int cynicism;
        
        [Tooltip("Skip from this dialog.")]
        public int redirectStart;
        [Tooltip("Skip to this dialog.")]
        public int redirectEnd;

        //[SerializeField]
        //public DialogText _DialogText = new DialogText(); 
    }

    [Serializable]
    public class MonologDialogClass
    {
        [Tooltip("Dialog text.")]
        public string speechText;
        [Tooltip("Is this text supposed to be bold.")]
        public bool bold;
    }
}
