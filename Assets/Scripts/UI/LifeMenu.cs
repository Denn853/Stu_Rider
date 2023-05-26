using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeMenu : MonoBehaviour
{

    [Header("Text objects")]
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI lifesText;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = LevelController.instance.GetCurrentLevel();
        lifesText.text = "x " + GameManager.instance.GetLifes().ToString();
    }
}
