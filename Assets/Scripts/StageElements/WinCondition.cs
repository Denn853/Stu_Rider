using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [Header("Win Menu")]
    [SerializeField] private GameObject winMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
        winMenu.SetActive(true);
    }
}
