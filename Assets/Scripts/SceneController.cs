using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        instance = this;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Introduction()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void Missions()
    {
        SceneManager.LoadScene("Missions");
    }

    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void Race()
    {
        SceneManager.LoadScene("Race");
    }

    public void GameOverWin()
    {
        SceneManager.LoadScene("GameOverWin");
    }

    public void GameOverLose()
    {
        SceneManager.LoadScene("GameOverLose");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
