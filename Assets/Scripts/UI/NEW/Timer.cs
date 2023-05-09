using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Remaining time in seconds")]
    public float timeRemaining;
    [SerializeField] private TextMeshProUGUI timerText;

    [Header("Timer Status")]
    [SerializeField] private float timeElapsed;
    [SerializeField] private bool timeRunning;

    [Header("Lose")]
    [SerializeField] private GameObject loseMenu;

    [Header("Text Shake")]
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        timeRunning = true;
        timeElapsed = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRunning)
        {
            if (timeElapsed > 0.0f)
            {
                timeElapsed -= Time.deltaTime;
                DisplayTime(timeElapsed);

                if (timeElapsed < timeRemaining / 3 && Mathf.FloorToInt(timeElapsed) % 3 == 0)
                {
                    StartCoroutine(TextShake(duration));
                }
            }
            else
            {
                timeElapsed = 0.0f;
                timeRunning = false;
                ShowLoseMenu();
            }
        }
    }

    void DisplayTime(float time)
    {
        time += 1;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float GetTimeRemaining()
    {
        return timeElapsed;
    }

    void ShowLoseMenu()
    {
        Time.timeScale = 0;
        loseMenu.SetActive(true);
    }

    IEnumerator TextShake(float duration)
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(duration);
        timerText.color = Color.red;
        yield return new WaitForSeconds(duration);
        timerText.color = Color.white;
    }
}
