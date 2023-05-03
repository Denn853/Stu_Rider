using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public static LevelController instance { get; private set; }

    [Header("Current Level")]
    [SerializeField] private string currentLevel;

    [Header("Win Condition")]
    [SerializeField] private int deliversToMake;
    [SerializeField] private GameObject winMenu;

    [Header("Lose Condition")]
    [SerializeField] private GameObject substactLifeMenu;

    [Header("Level Status")]
    [SerializeField] private int lifes;
    [SerializeField] private int deliversDone;

    float timer;

    [Header("Audio")]
    [SerializeField] private AudioSource reciveDamageSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource winSoundEffect;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        deliversDone = 0;
        lifes = 3;
        timer = 0.0f;

        Time.timeScale = 0;
        SubstractLife();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 3.0f)
        {
            timer += Time.unscaledDeltaTime;
            return;
        }

        if (substactLifeMenu.active && timer > 3.0f)
        {
            Time.timeScale = 1;
            substactLifeMenu.SetActive(false);
        }

        if (deliversDone == deliversToMake)
            LevelWon();
    }

    public void LevelWon()
    {
        winSoundEffect.Play();

        Time.timeScale = 0;
        winMenu.SetActive(true);
    }

    void SubstractLife()
    {
        substactLifeMenu.SetActive(true);
    }

    public void TakeDamage()
    {
        reciveDamageSoundEffect.Play();

        lifes--;
    }

    public string GetCurrentLevel()
    {
        return currentLevel;
    }

    public int GetLifes()
    {
        return lifes;
    }
}
