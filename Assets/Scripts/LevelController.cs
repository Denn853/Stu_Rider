using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LevelController : MonoBehaviour
{

    public static LevelController instance { get; private set; }

    [Header("Current Level")]
    [SerializeField] private string currentLevel;

    [Header("Win Condition")]
    [SerializeField] private int deliversToMake;
    [SerializeField] private GameObject winMenu;

    [Header("Life Menu Start")]
    [SerializeField] private GameObject lifesMenu;

    [Header("Level Status")]
    [SerializeField] private int lifes;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private int deliversDone;

    float timer;

    [Header("Audio")]
    [SerializeField] private AudioSource levelMusic;
    [SerializeField] private AudioSource levelAmbience;
    [SerializeField] private AudioSource reciveDamageSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource winSoundEffect;
    [SerializeField] private SettingsMenu audioSettings;
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer sfxMixer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        deliversDone = 0;
        lifes = hearts.Length;
        timer = 0.0f;

        Time.timeScale = 0;

        musicMixer.SetFloat("mainVolume", -50.0f);
        sfxMixer.SetFloat("mainVolume", -50.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 3.0f)
        {
            timer += Time.unscaledDeltaTime;
            lifesMenu.SetActive(true);
            return;
        }

        if (lifesMenu.active && timer > 3.0f)
        {
            levelMusic.Play();
            levelAmbience.Play();
            lifesMenu.SetActive(false);
            Time.timeScale = 1;
            audioSettings.MuteAll();
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

    private void CheckLife()
    {
        if (lifes < 6)
        {
            Destroy(hearts[0].gameObject);
        }
        if (lifes < 5)
        {
            Destroy(hearts[1].gameObject);
        }
        if (lifes < 4)
        {
            Destroy(hearts[2].gameObject);
        }
        if (lifes < 3)
        {
            Destroy(hearts[3].gameObject);
        }
        if (lifes < 2)
        {
            Destroy(hearts[4].gameObject);
        }
        if (lifes < 1)
        {
            Destroy(hearts[5].gameObject);
        }
    }

    public void TakeDamage()
    {
        reciveDamageSoundEffect.Play();

        lifes--;
        CheckLife();
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
