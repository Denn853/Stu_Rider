using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int lifes = 3;
    public bool gameOver = false;

    private void Awake()
    {
        instance = this;
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
        }
    }
}
