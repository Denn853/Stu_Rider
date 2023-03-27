using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public SceneController controller;
    // Start is called before the first frame update
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Dennys Moto", LoadSceneMode.Single);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Oriol", LoadSceneMode.Single);
    }

    public void Reanude()
    {
        UIManager.instance.ReanudeGame();
    }

    public void OptionsButton()
    {

    }

    public void ExitOptions()
    {

    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
