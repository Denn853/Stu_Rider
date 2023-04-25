using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    public GameObject unlockImage;
    
    public Animator anim;
    private SceneControl sceneCtrl;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
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
            //anim.SetBool("isUnlock", true);
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
