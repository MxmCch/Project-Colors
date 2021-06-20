using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
    public float volume;
    public float mouseSensitivity;
    public int graphicsQuality;

    public SettingsData(Setting setting)
    {
        volume = setting.volume;
        mouseSensitivity = setting.mouseSensitivity;
        graphicsQuality = setting.graphicsQuality;
    }
}
