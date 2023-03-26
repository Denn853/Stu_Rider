using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    public int lifes = 3;
    public bool gameOver = false;

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
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifes <= 0)
        {
            gameOver = true;
            UIManager.instance.DeathPanel();
        }
    }
}
