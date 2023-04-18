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
            }
            else
            {
                timeElapsed = timeRemaining;
                timeRunning = false;
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
}
