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

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused)
        {
            ShowPauseMenu();
        }
        else if (Input.GetButtonDown("Cancel") && isPaused)
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
    }
}
