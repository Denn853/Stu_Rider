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

    float volumeMusic;
    float volumeSFX;

    float minVolumeMusic;
    float minVolumeSFX;

    private void Start()
    {
        minVolumeMusic = -40.0f;
        minVolumeSFX = -40.0f;

        mainAudioMixer.GetFloat("mainVolume", out volumeMusic);
        mainAudioMixer.GetFloat("sfxVolume", out volumeMusic);

        mainSliderBar.value = volumeMusic;
        sfxSliderBar.value = volumeSFX;
    }
    public void SetMainVolume(float volume)
    {
        mainAudioMixer.SetFloat("mainVolume", volume);
        volumeMusic = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxAudioMixer.SetFloat("sfxVolume", volume);
        volumeSFX = volume;
    }

    public void MuteAll()
    {

        if (muteToggle.isOn)
        {
            mainSliderBar.interactable = false;
            sfxSliderBar.interactable = false;

            SetMainVolume(minVolumeMusic);
            SetSFXVolume(minVolumeSFX);

            mainSliderBar.value = minVolumeMusic;
            sfxSliderBar.value = minVolumeSFX;
        }
        else
        {
            mainSliderBar.interactable = true;
            sfxSliderBar.interactable = true;

            SetMainVolume(volumeMusic);
            SetSFXVolume(volumeSFX);

            mainSliderBar.value = volumeMusic;
            sfxSliderBar.value = volumeSFX;
        }
    }
}
