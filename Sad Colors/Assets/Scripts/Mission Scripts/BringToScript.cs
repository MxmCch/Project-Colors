using UnityEngine;
using TMPro;

public class BringToScript : MonoBehaviour
{
    [SerializeField]
    GameObject bringTo;
    [SerializeField]
    TextMeshProUGUI questLine;
    
    [SerializeField]
    ChangeQuest _ChangeQuest;

    [SerializeField]
    EmotionClass _EmotionClass;
    
    [SerializeField]
    Dialog _Dialog;

    [SerializeField]
    GameObject particles;
    
    [SerializeField]
    Dialog.DialogText[] _NewDialogArray;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == bringTo.name)
        {
            particles.SetActive(false);
            questLine.color = new Color32(125,255,100,255);
            VibeChanger _VibeChanger = this.gameObject.GetComponent<VibeChanger>();

            _Dialog._DialogArray = _NewDialogArray;
            _Dialog.GetComponent<EmotionClass>().ChangeEmotions(150,150,0,0);
            _VibeChanger.ChangeColor(
                Color.yellow*150/255,
                Color.red*0/255,
                Color.green*150/255,
                Color.blue*0/255
            );
            other.gameObject.SetActive(false);
            _ChangeQuest.CheckFinal();
        }
    }
}
