using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    public GameObject unlockImage;

    public int level;
    
    public Animator anim;
    private SceneControl sceneCtrl;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        unlocked = level < GameManager.instance.level;
        UpdateLevelImage();
    }

    private void UpdateLevelImage()
    {
        if (!unlocked)
        {
            unlockImage.gameObject.SetActive(true);
        }
        else
        {
            unlockImage.gameObject.SetActive(false);
        }
    }

    public void PressSelection(string _LevelName)
    {
        if (unlocked)
        {
            //sceneCtrl.Level1();
            SceneManager.LoadScene(_LevelName);
        }
    }
}
