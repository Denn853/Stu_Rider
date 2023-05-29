using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    public int lifes;
    public int level;

    public float musicAudio;
    public float sfxAudio;

    public bool introPlayed;

    public bool isImmortal;
    public bool isJumpInifinite;

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
        introPlayed = false
            ;
        isImmortal = false;
        //level = 1;
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
        level = 1;
    }
}
