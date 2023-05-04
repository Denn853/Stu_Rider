using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [Header("Win Menu")]
    [SerializeField] private GameObject winMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.lifes = 3;
        Time.timeScale = 0;
        winMenu.SetActive(true);
        
        switch(LevelController.instance.GetCurrentLevel())
        {
            case "Level 1":
                if (GameManager.instance.level < 2)
                    GameManager.instance.level = 2;
                break;

            case "Level 2":
                if (GameManager.instance.level < 3)
                    GameManager.instance.level = 3;
                break;

            case "Level 3":
                if (GameManager.instance.level < 4)
                    GameManager.instance.level = 4;
                break;

            case "Level 4":
                if (GameManager.instance.level < 5)
                    GameManager.instance.level = 5;
                break;
        }
    }
}
