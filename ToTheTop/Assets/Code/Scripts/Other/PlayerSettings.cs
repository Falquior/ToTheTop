using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputNickname;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider dialogueSpeedSlider;

    private string nickname = "Nickname";
    private string sfxVolume = "SfxVolume";
    private string musicVolume = "MusicVolume";
    private string dialogueSpeed = "DialogueSpeed";

    private string defaultNickname = "Mary";
    private float defaultSfxVolume = 0.2f;
    private float defaultMusicVolume = 0.03f;
    private float defaultDialogueSpeed = 0.02f;

    private void Start()
    {
        LoadSettings();
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey(nickname))
        {
            inputNickname.text = PlayerPrefs.GetString(nickname);
        }
        else
        {
            inputNickname.text = defaultNickname;
            PlayerPrefs.SetString(nickname, defaultNickname);
        }

        if (PlayerPrefs.HasKey(sfxVolume))
        {
            sfxSlider.value = PlayerPrefs.GetFloat(sfxVolume);
        }
        else
        {
            sfxSlider.value = defaultSfxVolume;
            PlayerPrefs.SetFloat(sfxVolume, defaultSfxVolume);
        }

        if (PlayerPrefs.HasKey(musicVolume))
        {
            musicSlider.value = PlayerPrefs.GetFloat(musicVolume);
        }
        else
        {
            musicSlider.value = defaultMusicVolume;
            PlayerPrefs.SetFloat(musicVolume, defaultMusicVolume);
        }

        if (PlayerPrefs.HasKey(dialogueSpeed))
        {
            dialogueSpeedSlider.value = PlayerPrefs.GetFloat(dialogueSpeed);
        }
        else
        {
            dialogueSpeedSlider.value = defaultDialogueSpeed;
            PlayerPrefs.SetFloat(dialogueSpeed, defaultDialogueSpeed);
        }
    }

    public void SetNickname()
    {
        PlayerPrefs.SetString(nickname, inputNickname.text);
    }

    public void SetSfxVolume()
    {
        PlayerPrefs.SetFloat(sfxVolume, sfxSlider.value);
    }

    public void SetMusicVolume()
    {
        PlayerPrefs.SetFloat(musicVolume, musicSlider.value);
    }

    public void SetDialogueSpeed()
    {
        PlayerPrefs.SetFloat(dialogueSpeed, dialogueSpeedSlider.value);
    }
}
