using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    int sceneNum;

    [SerializeField]
    bool loadEnable = true;

    private void OnEnable() {
        //Good cutscene
        if (loadEnable)
        {
            SceneManager.LoadScene(sceneNum);
        }
    }

    public void LoadSceneButton(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
