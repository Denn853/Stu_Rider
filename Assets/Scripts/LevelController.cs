using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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
    [SerializeField] public List<Image> hearts = new List<Image>();
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
        lifes = hearts.Count / 3;
        timer = 0.0f;

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 3.0f)
        {
            musicMixer.SetFloat("mainVolume", -80.0f);
            sfxMixer.SetFloat("sfxVolume", -80.0f);
            timer += Time.unscaledDeltaTime;
            lifesMenu.SetActive(true);
            return;
        }

        if (lifesMenu.active && timer > 3.0f)
        {
            musicMixer.SetFloat("mainVolume", GameManager.instance.musicAudio);
            sfxMixer.SetFloat("sfxVolume", GameManager.instance.sfxAudio);
            levelMusic.Play();
            levelAmbience.Play();
            lifesMenu.SetActive(false);
            Time.timeScale = 1;
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
            StartCoroutine(UnfillBarCorrutine(17, 15));
        }
        if (lifes < 5)
        {
            StartCoroutine(UnfillBarCorrutine(14, 12));
        }
        if (lifes < 4)
        {
            StartCoroutine(UnfillBarCorrutine(11, 9));
        }
        if (lifes < 3)
        {
            StartCoroutine(UnfillBarCorrutine(8, 6));
        }
        if (lifes < 2)
        {
            StartCoroutine(UnfillBarCorrutine(5, 3));
        }
        if (lifes < 1)
        {
            StartCoroutine(UnfillBarCorrutine(2, 0));
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

    IEnumerator UnfillBarCorrutine(int max, int min)
    {
        for (int i = max; i >= min; i--)
        {
            for(float j = 1.0f; j >= -1.0f; j -= 0.10f)
            {
                hearts[(int)i].fillAmount = j;
            }
            yield return new WaitForSeconds(0.15f);
        }
    }
}
