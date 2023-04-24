using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{

    [Header("Audio Mixer References")]
    public AudioMixer mainAudioMixer;
    public AudioMixer sfxAudioMixer;

    [Header("Not interactable")]
    public Toggle muteToggle;
    public Slider mainSliderBar;
    public Slider sfxSliderBar;
        
    public void SetMainVolume(float volume)
    {
        mainAudioMixer.SetFloat("mainVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxAudioMixer.SetFloat("sfxVolume", volume);
    }

    public void MuteAll()
    {
        SetMainVolume(-80.0f);
        SetSFXVolume(-80.0f);
        
        mainSliderBar.value = -80.0f;
        sfxSliderBar.value = -80.0f;

        if (muteToggle.isOn)
        {
            mainSliderBar.interactable = false;
            sfxSliderBar.interactable = false;
        }
        else
        {
            mainSliderBar.interactable = true;
            sfxSliderBar.interactable = true;
        }
    }

    public void Back()
    {
        this.gameObject.active = false;
    }

}
