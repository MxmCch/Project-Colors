using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Martin
// Basic menu mechanic
public class MainMenu_Script : MonoBehaviour
{
    public GameObject menuBackground;

    private static byte red = 255;
    private static byte green = 0;
    private static byte blue = 0;

    // This function loads next scene in order from File -> Build Settings -> Scenes In Build
    // #TODO: List of saves
    public void PlayNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // #TODO: Load Menu UI
    // #TODO: Disable if no save exists
    public void ContinueGame()
    {
        Debug.Log("#TODO: CREATE LOAD MENU UI");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // This function loads the last scene in build, that should be Credits Scene
    public void Credits()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    // This function exits the aplication
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    // Basic RGB changing background
    private void FixedUpdate()
    {
        if (green == 255 && red > 0) red--; 
        else if (green == 255 && red == 0 && blue < 255) blue++; 
        else if (blue == 255 && green > 0) green--; 
        else if (blue == 255 && green == 0 && red < 255) red++; 
        else if (red == 255 && blue > 0) blue--; 
        else if (red == 255 && blue == 0 && green < 255) green++; 


        menuBackground.gameObject.GetComponent<Image>().color = new Color32(red, green, blue, 255);
    }
}
