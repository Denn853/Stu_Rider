using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    public List<GameObject> panels = new List<GameObject>();

    bool isPaused = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseMenu();
        }
    }

    public void ReceiveDamage()
    {
        panels[2].GetComponent<Lifes>().ReceiveDamage();
    }

    public void ResetLevel()
    {
        GameManager.instance.lifes = 3;
        GameManager.instance.gameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Oriol");
    }

    public void MainMenu()
    {
        GameManager.instance.lifes = 3;
        GameManager.instance.gameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    void PauseMenu()
    {

        if (GameManager.instance.gameOver)
        {
            return;
        }

        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            panels[2].SetActive(false);
            panels[1].SetActive(true);
            return; 
        }

        panels[1].SetActive(false);
        panels[2].SetActive(true);
        Time.timeScale = 1;
    }

    public void ReanudeGame()
    {
        panels[1].SetActive(false);
        panels[2].SetActive(true);
        Time.timeScale = 1;
    }

    public void DeathPanel()
    {
        Time.timeScale = 0;
        panels[2].SetActive(false);
        panels[0].SetActive(true);
    }

}
