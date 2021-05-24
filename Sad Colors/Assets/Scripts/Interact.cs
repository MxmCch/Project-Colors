using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interact : MonoBehaviour
{
    //Variables for GUI
    public TMP_Text PressF;
    public TMP_Text _DialogNameUI;
    public TMP_Text _DialogTextUI;
    public GameObject PressFPanel;
    public GameObject DialogPanel;
    //Variables for dialog text
    int TextDialogID = 0;
    public int NextPersonDialog = 0;
    public int CurrentStop;
    public int SkipDialog = 0;

    public Transform OtherTransform;
    public bool DecisionActive = false;
    Dialog _Dialogs;

    private void Start() 
    {
        DisplayPanel(false,false);
        NextPersonDialog = 0;
        TextDialogID = 0;
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Dialog")
        {
            _Dialogs = other.gameObject.GetComponent<Dialog>();
            OtherTransform = other.gameObject.GetComponent<Transform>();
            SkipDialog = _Dialogs.ThisSkipDialog;
            PressFPanel.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Dialog")
        {
            OtherTransform = null;
            DisplayPanel(false,false);
            TextDialogID = 0;
            NextPersonDialog = 0;
            SkipDialog = 0;
        }
    }
    
    void Update() 
    {
        if (Input.GetKeyDown("p"))
        {
            //SaveSystem.SavePlayer(this);
            Debug.Log("Progress has been saved!");
        }
        else if (Input.GetKeyDown("o"))
        {
            PlayerData data = SaveSystem.LoadPlayer();
            //level = data.level;
            Debug.Log("All data loaded!");
        }
        else if (Input.GetKeyDown("l"))
        {
            
        }

        //Only if a panel shows up, player will be able to interact with it's surrounding
        if (PressFPanel.activeInHierarchy == true || DialogPanel.activeInHierarchy == true)
        {
            if (Input.GetKeyDown("f") && NextPersonDialog+SkipDialog < _Dialogs.DialogArray.Length)
            {
                _DialogNameUI.text = _Dialogs.DialogArray[NextPersonDialog+SkipDialog].NPCDialogName;
                _DialogTextUI.text = _Dialogs.DialogArray[NextPersonDialog+SkipDialog].TextDialog[TextDialogID];

                // TextDialogID = Dialog text order in which the NPC talks
                // NewDialog = Next persons dialog
                // TextDialog = NPC dialog text
                TextDialogID++;
                if (TextDialogID == _Dialogs.DialogArray[NextPersonDialog+SkipDialog].TextDialog.Length)
                {
                    if (_Dialogs.DialogArray[NextPersonDialog+SkipDialog].ChoiceObjects.Length != 0)
                    {
                        TextDialogID = 0;
                        CurrentStop = NextPersonDialog+SkipDialog;
                        if (OtherTransform.childCount == 0 && DecisionActive == false)
                        {
                            CreateChoices();
                        }
                        else if (OtherTransform.childCount == 0 && DecisionActive == true)
                        {
                            GameObject[] oldDecisions = GameObject.FindGameObjectsWithTag("Decision");
                            foreach (GameObject oldDecision in oldDecisions)
                            {
                                Destroy(oldDecision);
                            }
                            CreateChoices();
                        }
                        NextPersonDialog = 0;
                    }
                    else
                    {
                        NextPersonDialog++;
                        if (NextPersonDialog+SkipDialog == _Dialogs.DialogArray.Length)
                        {
                            NextPersonDialog = 0;
                        }
                        TextDialogID = 0;
                    }
                }
                DisplayPanel(true,false);
            }
        }
    }

    //spawning choices infront of NPC 
    private void CreateChoices()
    {
        DecisionActive = true;

        //OtherTransform = ColissionEnter(other) = NPC
        //Distance of one point in front of NPC and one point left
        Vector3 xz = OtherTransform.position + OtherTransform.forward - OtherTransform.right;
        
        //Setting position of firt choice, infront of NPC to the left
        float x = xz.x;
        float y = OtherTransform.position.y;
        float z = xz.z;

        float totalChoices = _Dialogs.DialogArray[NextPersonDialog + SkipDialog].ChoiceObjects.Length;
        float evenTotal = 0;
        Vector3 newXZ = OtherTransform.forward + OtherTransform.right/evenTotal;

        if (totalChoices % 2 == 1)
        {
            evenTotal = (totalChoices-1)/2;
            newXZ = OtherTransform.right/evenTotal;
        } 
        else if (totalChoices % 2 == 0)
        {
            evenTotal = totalChoices/2 + 1;
            newXZ = OtherTransform.right/evenTotal;
        }

        //even choices, need to be moved before spawning 
        Vector3 instantiateLocation = new Vector3(x, y, z);
        if (totalChoices % 2 == 0)
        {
            instantiateLocation += newXZ/2;
        }

        foreach (GameObject decisionOBJ in _Dialogs.DialogArray[NextPersonDialog + SkipDialog].ChoiceObjects)
        {
            if (totalChoices % 2 == 0)
            {
                instantiateLocation += newXZ;
            }
            Instantiate(decisionOBJ, instantiateLocation, Quaternion.identity, OtherTransform);
            if (totalChoices % 2 ==1)
            {
                instantiateLocation += newXZ;
            }
        }
    }

    //Displays GUI text, "Press F.." and Dialog window
    void DisplayPanel(bool dialogPanelBool, bool PressFBool)
    {
        DialogPanel.SetActive(dialogPanelBool);
        PressFPanel.SetActive(PressFBool);
    }
}
