using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    public int lifes;

    private string currentLevel;

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

    // Start is called before the first frame update
    void Start()
    {
        lifes = 3;
        currentLevel = "Level1";
    }

    // Update is called once per frame
    void Update()
    {
        if (lifes <= 0)
        {
        }
    }

    public void SubstractLife()
    {
        lifes--;
    }

    public int GetLifes()
    {
        return lifes;
    }

    public void ResetGame()
    {
        currentLevel = "Level1";
    }

    public void ReceiveDamage() { }
}
