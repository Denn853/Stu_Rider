using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes { MAINMENU, SELECTOR, LEVEL1, LEVEL2, LEVEL3, LEVEL4, CREDITS }

public class SceneControl : MonoBehaviour
{

    public static SceneControl instance;

    [SerializeField] private List<string> sceneList = new List<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("Warning: Multiple " + this + " in scene!");
            Destroy(this);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneList[(int)Scenes.MAINMENU], LoadSceneMode.Single);
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene(sceneList[(int)Scenes.SELECTOR], LoadSceneMode.Single);
    }

    public void Level1()
    {
        SceneManager.LoadScene(sceneList[(int)Scenes.LEVEL1], LoadSceneMode.Single);
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
