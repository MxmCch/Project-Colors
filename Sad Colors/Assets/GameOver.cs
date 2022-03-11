using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    int waitTime;

    private void OnEnable() {
        //Good cutscene
        StartCoroutine(ExitToMenu());
    }

    IEnumerator ExitToMenu()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);
    }
}
