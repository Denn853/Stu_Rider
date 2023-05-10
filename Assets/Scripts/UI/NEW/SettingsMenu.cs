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

    float volumeMusicBackup;
    float volumeSFXBackup;

    float minVolumeMusic;
    float minVolumeSFX;

    private void Start()
    {
        minVolumeMusic = -50.0f;
        minVolumeSFX = -50.0f;

        mainAudioMixer.GetFloat("mainVolume", out volumeMusic);
        sfxAudioMixer.GetFloat("sfxVolume", out volumeSFX);

        volumeMusicBackup = volumeMusic;
        volumeSFXBackup = volumeSFX;

        mainSliderBar.value = volumeMusic;
        sfxSliderBar.value = volumeSFX;

    }
    public void SetMainVolume(float volume)
    {
        mainAudioMixer.SetFloat("mainVolume", volume);
        volumeMusic = volume;
        mainSliderBar.value = volumeMusic;
    }

    public void SetSFXVolume(float volume)
    {
        sfxAudioMixer.SetFloat("sfxVolume", volume);
        volumeSFX = volume;
        sfxSliderBar.value = volumeSFX;
    }

    public void MuteAll()
    {

        if (muteToggle.isOn)
        {
            SetToMin();
        }
        else
        {
            SetBack();
        }
    }

    public void SetToMin()
    {
        mainSliderBar.interactable = false;
        sfxSliderBar.interactable = false;

        volumeMusicBackup = volumeMusic;
        volumeSFXBackup = volumeSFX;

        mainAudioMixer.SetFloat("mainVolume", minVolumeMusic);
        sfxAudioMixer.SetFloat("sfxVolume", minVolumeSFX);

        mainSliderBar.value = minVolumeMusic;
        sfxSliderBar.value = minVolumeSFX;

        GameManager.instance.musicAudio = minVolumeMusic;
        GameManager.instance.sfxAudio = minVolumeSFX;
    }

    public void SetBack()
    {
        mainSliderBar.interactable = true;
        sfxSliderBar.interactable = true;

        mainAudioMixer.SetFloat("mainVolume", volumeMusic);
        sfxAudioMixer.SetFloat("sfxVolume", volumeSFX);

        mainSliderBar.value = volumeMusicBackup;
        sfxSliderBar.value = volumeSFXBackup;

        GameManager.instance.musicAudio = volumeMusicBackup;
        GameManager.instance.sfxAudio = volumeSFXBackup;
    }

    public float GetValuesMain()
    {
        return volumeMusicBackup;
    }

    public float GetValuesSFX()
    {
        return volumeSFXBackup;
    }
}
