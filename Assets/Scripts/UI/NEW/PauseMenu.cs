using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;

    [Header("Settings Menu")]
    [SerializeField] private GameObject settingsMenu;

    [Header("Pause Status")]
    [SerializeField] private bool isPaused;
    [SerializeField] private bool areSettings;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        areSettings = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused)
        {
            ShowPauseMenu();
        }
        else if (Input.GetButtonDown("Cancel") && isPaused && !areSettings)
        {
            HidePauseMenu();
        }
    }

    public void ShowPauseMenu()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void ShowSettingsMenu()
    {
        settingsMenu.SetActive(true);
        areSettings = true;
    }

    public void HideSettingsMenu()
    {
        settingsMenu.SetActive(false);
        areSettings = false;
    }

    public void GoToLevelSelector()
    {
        SceneControl.instance.LevelSelector();
    }
}
