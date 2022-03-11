using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Interact : MonoBehaviour
{
    //Variables for GUI
    public TMP_Text _DialogNameText;
    public TMP_Text _DialogTextText;
    public GameObject interactPanel;
    public GameObject dialogPanel;
    public GameObject answerPanel;

    public EmotionClass _EmotionClass;
    public GameObject emotionalGraphUI;
    bool emotionalGraphActive = false;
    
    //Variables for dialog text
    int textDialogID = 0;
    public int nextPersonDialog = 0;
    public int currentStop;
    public int skipDialog = 0;
    public int endDialog;

    public Transform otherTransform;
    public bool decisionActive = false;
    public Dialog _Dialog;

    public bool nextClickDisplayFalse = false;

    private void Start() 
    {
        emotionalGraphUI.SetActive(false);
        DisplayPanel(false,false,false);
        nextPersonDialog = 0;
        textDialogID = 0;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.GetComponent<Dialog>() != null)
        {
            _Dialog = other.gameObject.GetComponent<Dialog>();
            _EmotionClass = other.gameObject.GetComponent<EmotionClass>();
            otherTransform = other.gameObject.GetComponent<Transform>();
            skipDialog = _Dialog.thisSkipDialog;
            interactPanel.SetActive(true);
            nextClickDisplayFalse = false;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.GetComponent<CharacterNavigationController>())
        {
            if (Input.GetKeyDown("f"))
            {
                other.GetComponent<CharacterNavigationController>().isTalking = 0;
                Vector3 thisTransform = this.gameObject.transform.position;
                other.transform.LookAt(new Vector3(thisTransform.x,other.transform.GetChild(0).transform.position.y-0.5f,thisTransform.z));
            }
        }
    }
    
    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<Dialog>() != null)
        {
            decisionActive = false;
            otherTransform = null;
            DisplayPanel(false,false,false);
            textDialogID = 0;
            nextPersonDialog = 0;
            skipDialog = 0;
            nextClickDisplayFalse = false;
        }
        if (other.GetComponent<CharacterNavigationController>())
        {
            other.GetComponent<CharacterNavigationController>().isTalking = 1;
        }
    }
    
    private Coroutine DisplayLineCoroutine;

    private void Update() 
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
        else if (Input.GetKeyDown("m"))
        {
            emotionalGraphActive = !emotionalGraphActive;
            emotionalGraphUI.SetActive(emotionalGraphActive);
        }

        //Only if a panel shows up, player will be able to interact with it's surrounding
        if (interactPanel.activeInHierarchy == true || dialogPanel.activeInHierarchy == true)
        {
            if (Input.GetKeyDown("f") && nextPersonDialog+skipDialog < _Dialog._DialogArray.Length && !(answerPanel.gameObject.activeSelf))
            {
                _DialogNameText.text = _Dialog._DialogArray[nextPersonDialog+skipDialog].talkingPersonName;
                //_DialogTextText.text = _Dialog._DialogArray[nextPersonDialog+skipDialog].MonologDialog[textDialogID].speechText;
                if (DisplayLineCoroutine != null)
                {
                    StopCoroutine(DisplayLineCoroutine);
                }
                DisplayLineCoroutine = StartCoroutine(DisplayLine(_Dialog._DialogArray[nextPersonDialog+skipDialog].MonologDialog[textDialogID].speechText,_DialogTextText));


                if (nextClickDisplayFalse)
                {
                    DisplayPanel(false,true,false);
                    nextClickDisplayFalse = false;
                    return;
                } else {
                    DisplayPanel(true,false,false);
                }
                // TextDialogID = Dialog text order in which the NPC talks
                // NewDialog = Next persons dialog
                // TextDialog = NPC dialog text
                textDialogID++;
                if (textDialogID == _Dialog._DialogArray[nextPersonDialog+skipDialog].MonologDialog.Length)
                {
                    if (_Dialog._DialogArray[nextPersonDialog+skipDialog].DialogAnswer.Length != 0)
                    {
                        textDialogID = 0;
                        currentStop = nextPersonDialog+skipDialog;
                        if (decisionActive == false)
                        {
                            CreateChoices();
                        }
                        nextPersonDialog = 0;
                    }
                    else
                    {
                        if (_Dialog.finishedDialog)
                        {
                            if (nextPersonDialog + skipDialog == endDialog)
                            {
                                nextPersonDialog = 0;
                                nextClickDisplayFalse = true;
                            }else{
                                nextPersonDialog++; 
                            }
                        }
                        else
                        {
                            if (nextPersonDialog+1 == _Dialog._DialogArray.Length)
                            {
                                nextPersonDialog = 0;
                                nextClickDisplayFalse = true;
                            }else{
                                nextPersonDialog++; 
                            }
                        }
                        textDialogID = 0;
                    }
                }
            }
        }
    }

    private IEnumerator DisplayLine(string line, TMP_Text textChange)
    {
        textChange.text = "";

        foreach (char letter in line.ToCharArray())
        {
            textChange.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void CreateChoices()
    {
        decisionActive = true;
        DisplayPanel(true,false,true);
        int x = answerPanel.transform.childCount;
        int y = _Dialog._DialogArray[nextPersonDialog + skipDialog].DialogAnswer.Length;

        for (int i = 0; i < x; i++)
        {
            if (i < y)
            {
                answerPanel.transform.GetChild(i).gameObject.SetActive(true);
                answerPanel.transform.GetChild(i).gameObject.name = i.ToString();
                answerPanel.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = _Dialog._DialogArray[nextPersonDialog + skipDialog].DialogAnswer[i].dialogAnswer;
            }
            else
            {
                answerPanel.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    //Displays GUI text, "Press F.." and Dialog window
    private void DisplayPanel(bool dialogPanelBool, bool PressFBool, bool answersBool)
    {
        dialogPanel.SetActive(dialogPanelBool);
        interactPanel.SetActive(PressFBool);
        answerPanel.SetActive(answersBool);
    }
}
