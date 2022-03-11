using UnityEngine;
using TMPro;

public class TellNicoleCompliment : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI questLine;

    [SerializeField]
    bool compliment;

    [SerializeField]
    GameObject particles;

    [SerializeField]
    EmotionClass _EmotionClass;

    [SerializeField]
    ChangeQuest _ChangeQuest;

    private void OnEnable() 
    {
        if (compliment)
        {
            particles.SetActive(false);
            _EmotionClass.ChangeEmotions(150,150,0,0);
            questLine.color = new Color32(125,255,100, 255);
            _ChangeQuest.CheckFinal();
        }
        else
        {
            particles.SetActive(false);
            _EmotionClass.ChangeEmotions(0,0,20,180);
            questLine.color = new Color32(255,20,20, 255);
        }
    }
}
