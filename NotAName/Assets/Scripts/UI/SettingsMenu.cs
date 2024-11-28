using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Tabs")]
    [SerializeField] private GameObject gameTab;
    [SerializeField] private GameObject inputTab;
    [SerializeField] private GameObject audioTab;

    [Header("Bindings Tabs")]
    [SerializeField] private GameObject keyboardTab;
    [SerializeField] private GameObject gamepadTab;

    [Header("Other")]
    [SerializeField] private GameObject cam;
    [SerializeField] public bool isMainMenu;

    [Header("Game")]
    [SerializeField] private CustomSlider brightnessSlider;
    [SerializeField] private Toggle fullscreenToggle;

    [Header("Audio")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private CustomSlider masterVolumeSlider;
    [SerializeField] private CustomSlider musicVolumeSlider;

    [SerializeField] private CustomSlider effectsVolumeSlider;

    [Header("Input")]
    [SerializeField] private CustomSlider sensitivitySlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnEnable()
    {
        gameTab.SetActive(true);
        inputTab.SetActive(false);
        audioTab.SetActive(false);
        if (InputSystem.GetDevice<Gamepad>() != null)
        {
            keyboardTab.SetActive(false);
            gamepadTab.SetActive(true);
        }
        else
        {
            keyboardTab.SetActive(true);
            gamepadTab.SetActive(false);
        }

        masterVolumeSlider.UpdateValue(PlayerPrefs.GetFloat("MasterVolume", 0) + 50);
        mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume", 0));

        musicVolumeSlider.UpdateValue(PlayerPrefs.GetFloat("MusicVolume", 0) + 50);
        mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", 0));

        effectsVolumeSlider.UpdateValue(PlayerPrefs.GetFloat("EffectsVolume", 0) + 50);
        mixer.SetFloat("EffectsVolume", PlayerPrefs.GetFloat("EffectsVolume", 0));

        sensitivitySlider.UpdateValue(PlayerPrefs.GetFloat("Sensitivity", 50));
        if (UserInput.Instance != null)
        {
            UserInput.Instance.CameraSensitivity = PlayerPrefs.GetFloat("Sensitivity", 50);
        }

        fullscreenToggle.isOn = PlayerPrefs.GetInt("FullScreen", 1) == 1;
        Screen.fullScreen = fullscreenToggle.isOn;

        brightnessSlider.UpdateValue(PlayerPrefs.GetFloat("Brightness", 50));
        // RenderSettings.ambientLight = new Color(brightnessSlider.value / 100, brightnessSlider.value / 100, brightnessSlider.value / 100);
    }

    // Update is called once per frame
    void Update()
    {
        MasterVolume();
        MusicVolume();
        EffectsVolume();
        Sensitivity();
        FullScreen();
        Brightness();
    }

    public void MainMenu()
    {
        if (isMainMenu)
        {
            cam.GetComponent<Animator>().SetBool("IsOnSettings", false);
        }
        else
        {
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void GameTab()
    {
        gameTab.SetActive(true);
        inputTab.SetActive(false);
        audioTab.SetActive(false);
    }

    public void InputTab()
    {
        gameTab.SetActive(false);
        inputTab.SetActive(true);
        audioTab.SetActive(false);
    }

    public void AudioTab()
    {
        gameTab.SetActive(false);
        inputTab.SetActive(false);
        audioTab.SetActive(true);
    }

    public void VideoTab()
    {
        gameTab.SetActive(false);
        inputTab.SetActive(false);
        audioTab.SetActive(false);
    }

    public void KeyboardTab()
    {
        keyboardTab.SetActive(true);
        gamepadTab.SetActive(false);
    }

    public void GamepadTab()
    {
        keyboardTab.SetActive(false);
        gamepadTab.SetActive(true);
    }

    public void MasterVolume()
    {
        mixer.SetFloat("MasterVolume", masterVolumeSlider.value - 50);
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value - 50);
    }

    public void MusicVolume()
    {
        mixer.SetFloat("MusicVolume", musicVolumeSlider.value - 50);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value - 50);
    }

    public void EffectsVolume()
    {
        mixer.SetFloat("EffectsVolume", effectsVolumeSlider.value - 50);
        PlayerPrefs.SetFloat("EffectsVolume", effectsVolumeSlider.value - 50);
    }

    public void Sensitivity()
    {
        UserInput.Instance.CameraSensitivity = sensitivitySlider.value;
        PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
    }

    public void FullScreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
        PlayerPrefs.SetInt("FullScreen", fullscreenToggle.isOn ? 1 : 0);
    }

    public void Brightness()
    {
        // RenderSettings.ambientLight = new Color(brightnessSlider.value / 100, brightnessSlider.value / 100, brightnessSlider.value / 100);
        PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
    }
}
