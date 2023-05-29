using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public float duration = 10;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoToLevelSelector", duration);
    }

    public void GoToLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector", LoadSceneMode.Single);
    }
}
