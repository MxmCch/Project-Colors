using System.Collections;
using UnityEngine;
using TMPro;

public class ChooseAnswer : MonoBehaviour
{
    public EmotionGraph emotionGraph;
    GameObject playerContainer;
    ChoiceArchive _ChoiceArchive;
    Dialog _Dialog;
    Interact _Interact;
    EmotionClass _EmotionClass;
    VibeChanger _VibeChanger;

    int answerIndex;
    
    void Start()
    {
        _ChoiceArchive = this.gameObject.GetComponent<ChoiceArchive>();
        //_Interact = this.gameObject.GetComponent<Interact>();
    }

    public void ChooseAnswerButton(GameObject playerInteract)
    {
        int answerIndex = int.Parse(this.gameObject.name); 

        _Interact = playerInteract.gameObject.GetComponent<Interact>();
        _Dialog = playerInteract.gameObject.GetComponent<Interact>()._Dialog;
        _EmotionClass = playerInteract.gameObject.GetComponent<Interact>()._EmotionClass;
        _VibeChanger = _Interact.otherTransform.GetChild(0).gameObject.GetComponent<VibeChanger>();


        int getNewDialog = _Interact.nextPersonDialog;
        int CurrentStop = _Interact.currentStop;
        _Interact.skipDialog = _Dialog._DialogArray[CurrentStop].DialogAnswer[answerIndex].redirectStart;
        _Interact.endDialog = _Dialog._DialogArray[CurrentStop].DialogAnswer[answerIndex].redirectEnd;
        _Dialog.thisSkipDialog = CurrentStop + _Dialog._DialogArray[CurrentStop].DialogAnswer[answerIndex].redirectStart;
        _Dialog.thisEndDialog = CurrentStop + _Dialog._DialogArray[CurrentStop].DialogAnswer[answerIndex].redirectEnd;
        _Dialog._DialogArray[CurrentStop].finalAnswer = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text; 
        _Dialog.finishedDialog = true; 

        _EmotionClass.hope = _Dialog._DialogArray[CurrentStop].DialogAnswer[answerIndex].hope;
        _EmotionClass.curiosity = _Dialog._DialogArray[CurrentStop].DialogAnswer[answerIndex].curiosity;
        _EmotionClass.unbelief = _Dialog._DialogArray[CurrentStop].DialogAnswer[answerIndex].unbelief;
        _EmotionClass.cynicism = _Dialog._DialogArray[CurrentStop].DialogAnswer[answerIndex].cynicism;

        emotionGraph.point.x += _EmotionClass.curiosity;
        emotionGraph.point.x -= _EmotionClass.cynicism;
        emotionGraph.point.y += _EmotionClass.hope;
        emotionGraph.point.y -= _EmotionClass.unbelief;


        emotionGraph.gameObject.SetActive(false);
        emotionGraph.gameObject.SetActive(true);

        _VibeChanger.ChangeColor(
            Color.yellow*_EmotionClass.hope/255,
            Color.red*_EmotionClass.cynicism/255,
            Color.green*_EmotionClass.curiosity/255,
            Color.blue*_EmotionClass.unbelief/255
        );

        _Interact.decisionActive = false;
        StartCoroutine(HideThisParent());
    }

    public IEnumerator HideThisParent()
    {
        this.transform.parent.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
    }
}
