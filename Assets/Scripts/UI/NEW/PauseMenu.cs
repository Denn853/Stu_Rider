using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;

    [Header("Settings Menu")]
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject controlsMenu;

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
        if (Time.time < 0.1f) { return; }

        if (Input.GetButtonDown("Cancel") && !isPaused)
            ShowPauseMenu();
        else if (Input.GetButtonDown("Cancel") && isPaused)
        {
            HidePauseMenu();
            HideSettingsMenu();
            HideControlsMenu();
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
        isPaused = false;
        Time.timeScale = 1;
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

    public void ShowControlsMenu()
    {
        controlsMenu.SetActive(true);
    }

    public void HideControlsMenu()
    {
        controlsMenu.SetActive(false);
    }

    public void GoToLevelSelector()
    {
        Time.timeScale = 1;
        GameManager.instance.lifes = 3;
        SceneManager.LoadScene("LevelSelector", LoadSceneMode.Single);
    }

    public void GoToCredits()
    {
        Time.timeScale = 1;
        GameManager.instance.lifes = 3;
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }
}
