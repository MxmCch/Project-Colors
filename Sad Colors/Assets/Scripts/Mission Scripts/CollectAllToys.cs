using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectAllToys : MonoBehaviour
{
    [SerializeField]
    Dialog _Dialog;
    EmotionClass _EmotionClass;

    [SerializeField]
    VibeChanger _VibeChanger;

    [SerializeField]
    TextMeshProUGUI _QuestLine;
    
    [SerializeField]
    ChangeQuest _ChangeQuest;

    [SerializeField]
    GameObject particles;

    int pickedUp;

    [SerializeField]
    Transform pickUpToysParent;
    
    [SerializeField]
    Dialog.DialogText[] _NewDialogArray;


    private void OnEnable() 
    {
        particles.SetActive(false);
        _EmotionClass = _Dialog.GetComponent<EmotionClass>();
        _QuestLine.text = "Posbírej 5 hraček a pak to řekni Jakubovi.";
        foreach (Transform item in pickUpToysParent)
        {
            item.GetChild(0).GetComponent<ObjectOptions>().dissappear = true;
        }
    }

    public void CheckToys() 
    {
        pickedUp++;
        if (pickedUp != 5)
        {
            _QuestLine.text = "Posbírej 5 hraček a pak to řekni Jakubovi." + " - " + pickedUp.ToString();
        }
        else
        {
            StartCoroutine(FinishQuest());
            _ChangeQuest.CheckFinal();
        }
    }

    IEnumerator FinishQuest()
    {
        foreach (Transform item in pickUpToysParent)
        {
            item.GetChild(0).GetComponent<ObjectOptions>().dissappear = false;
        }
        _QuestLine.text = "Posbírej 5 hraček a pak to řekni Jakubovi." + " - " + pickedUp.ToString();
        _QuestLine.color = new Color32(125, 255, 100, 255);

        _Dialog._DialogArray = _NewDialogArray;
        _Dialog.thisSkipDialog = 0;
        _Dialog.thisEndDialog = 0;

        _EmotionClass.ChangeEmotions(100,200,0,0);

        _VibeChanger.ChangeColor(
            Color.yellow * 100 / 255,
            Color.green * 200 / 255,
            Color.red * 0 / 255,
            Color.blue * 0 / 255
        );
        yield return new WaitForSeconds(.5f);
        this.gameObject.SetActive(false);
        yield return null;
    }
}
