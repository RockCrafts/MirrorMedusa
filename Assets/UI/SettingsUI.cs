using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsUI : MonoBehaviour
{
    public TMP_Dropdown quality, antialiasing;
    public Slider volume;
    private void Awake()
    {
        ApplySettings();
    }
    private void OnEnable()
    {
        LoadSettings();
    }
    private void OnDisable()
    {
        PlayerPrefs.Save();
    }
    public void LoadSettings()
    {
        quality.value = PlayerPrefs.GetInt("quality", 2);
        antialiasing.value = PlayerPrefs.GetInt("antialiasing", 0);
        volume.value = PlayerPrefs.GetFloat("volume", 1f);
    }
    public void ApplySettings()
    {
        int q = PlayerPrefs.GetInt("quality", 2);
        int aa = PlayerPrefs.GetInt("antialiasing", 0);
        QualitySettings.SetQualityLevel(q);
        int v = aa == 0 ? 0 : 1;
        for (int i = 0; i < aa; i++)
        {
            v *= 2;
        }
        QualitySettings.antiAliasing = v;
        AudioListener.volume = Mathf.Clamp01(PlayerPrefs.GetFloat("volume", 1f));
    }
    public void HandleQualityChange(int q)
    {
        PlayerPrefs.SetInt("quality", q);
        ApplySettings();
    }
    public void HandleAAChange(int aa)
    {
        PlayerPrefs.SetInt("antialiasing", aa);
        ApplySettings();
    }
    public void HandleVolumeChange(float v)
    {
        PlayerPrefs.SetFloat("volume", v);
        ApplySettings();
    }
}
