using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

// Martin
// List of settings
public class Setting : MonoBehaviour
{
    public Slider volumeSlider;
    public float volume;
    public Slider mouseSensitivitySlider;
    public float mouseSensitivity;
    public TextMeshProUGUI graphicsQualityText;
    public int graphicsQuality;

    private readonly string[] graphicsQualityStrings = new string[] { "LOW", "MEDIUM", "HIGH" }; 

    // Saves settings
    public void SaveSettings()
    {
        volume = volumeSlider.value;
        mouseSensitivity = mouseSensitivitySlider.value;

        SaveSystem.SaveSettings(this);
    }

    // Loads settings
    public void LoadSettings()
    {
        string path = Application.persistentDataPath + "/settings.sc";
        if (File.Exists(path))
        {
            SettingsData data = SaveSystem.LoadSettings();

            volume = data.volume;
            mouseSensitivity = data.mouseSensitivity;
            graphicsQuality = data.graphicsQuality;

        } else
        {
            volume = .5f;
            mouseSensitivity = .5f;
            graphicsQuality = 2;
        }

        volumeSlider.value = volume;
        mouseSensitivitySlider.value = mouseSensitivity;
        graphicsQualityText.text = graphicsQualityStrings[graphicsQuality-1];
    }

    public void ChangeGraphicsQuality()
    {
        if (graphicsQuality == 3) graphicsQuality = 1;
        else graphicsQuality++;

        graphicsQualityText.text = graphicsQualityStrings[graphicsQuality-1];
    }
}
