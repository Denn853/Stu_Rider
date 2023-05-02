using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes { MAINMENU, SELECTOR, LEVEL1, LEVEL2, LEVEL3, LEVEL4, CREDITS }

public class SceneControl : MonoBehaviour
{

    public static SceneControl instance;

    [SerializeField] private List<string> sceneList = new List<string>();
    [SerializeField] private GameObject optionsMenu;

    private void Start()
    {
        optionsMenu = GameObject.FindGameObjectWithTag("optionsMenu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneList[(int)Scenes.LEVEL1], LoadSceneMode.Single);
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene(sceneList[(int)Scenes.SELECTOR], LoadSceneMode.Single);
    }

    public void Level1()
    {
        SceneManager.LoadScene(sceneList[(int)Scenes.LEVEL1], LoadSceneMode.Single);
    }

    public void ShowOptionsMenu()
    {
        optionsMenu.active = true;
    }

    public void HideOptionsMenu()
    {
        optionsMenu.active = false;
    }

    public void Credits()
    {
        SceneManager.LoadScene(sceneList[(int)Scenes.CREDITS], LoadSceneMode.Single);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
