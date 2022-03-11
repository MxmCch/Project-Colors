using UnityEngine;

public class ChangeQuest : MonoBehaviour
{
    public int finishedQuests;

    [SerializeField]
    GameObject teacher;

    [SerializeField]
    GameObject finalText;

    [SerializeField]
    GameObject[] beforeQuests;

    [SerializeField]
    GameObject particles;

    [SerializeField]
    Dialog.DialogText[] _NewDialogArray;

    private void OnEnable() {
        //Good cutscene
        //SceneManager.LoadScene(1);
    }

    public void CheckFinal()
    {
        finishedQuests++;
        if (finishedQuests == 4)
        {
            particles.SetActive(true);
            finalText.SetActive(true);
            foreach (var item in beforeQuests)
            {
                item.SetActive(false);
            }
            teacher.GetComponent<Dialog>().thisSkipDialog = 0;
            teacher.GetComponent<Dialog>().thisEndDialog = 0;
            teacher.GetComponent<Dialog>()._DialogArray = _NewDialogArray;
        }
    }
    
}
