using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Martin
// Basic pause mechanic
public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    // With this function you can resume the game
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // With this function you can pause the game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // This function opens UI menu with saves of the game, that can be loaded
    public void LoadMenu()
    {
        Debug.Log("#TODO: CREATE LOAD MENU UI");
    }

    // This function saves the game
    public void SaveGame()
    {
        Debug.Log("#TODO: CREATE SAVING MECHANIC");
    }

    // This function calls the save function and closes the application
    public void QuitGame()
    {
        SaveGame();
        Debug.Log("Quitting");
        Application.Quit();

        // !!! IMPORTANT !!!
        // REMOVE NEXT LINE BEFORE BUILDING
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
