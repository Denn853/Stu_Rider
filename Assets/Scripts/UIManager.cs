using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    public List<GameObject> panels = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public void ResetLevel()
    {
        GameManager.instance.lifes = 3;
        GameManager.instance.gameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Alejandro");
    }

    public void MainMenu()
    {
        GameManager.instance.lifes = 3;
        GameManager.instance.gameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void DeathPanel()
    {
        Time.timeScale = 0;
        panels[0].gameObject.SetActive(true);
    }

}
