using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    [SerializeField] private DashDHM dash;
    [SerializeField] private List<Image> dashBar = new List<Image>();
    float timeToVoid;
    float timeToFill;
    bool isVoiding;
    bool isFilling;

    private void Start()
    {
        isVoiding = false;
        isFilling = true;

        timeToVoid = dash.dashingTime / (200 * dashBar.Count);
        timeToFill = dash.coolDownTime / (200 * dashBar.Count);
    }

    private void Update()
    {
        if (!dash.canDash && !isVoiding)
        {
            StartCoroutine(VoidBar());
        }

        if (dash.cooldown && !isFilling)
        {
            StartCoroutine(FillBar());
        } 
    }

    IEnumerator VoidBar()
    {
        isVoiding = true;

        for (int i = dashBar.Count - 1; i >= 0; i-= 2)
        {
            dashBar[i].fillAmount = -1;

            if (i - 1 >= 0)
                dashBar[i - 1].fillAmount = -1;
            yield return new WaitForSeconds(timeToVoid);
        }

        isFilling = false;
    }

    IEnumerator FillBar()
    {
        isFilling = true;

        yield return new WaitForSeconds(timeToVoid);

        for (int i = 0; i <= dashBar.Count - 2; i+= 3)
        {
            dashBar[i].fillAmount = 1;
            dashBar[i + 1].fillAmount = 1;
            dashBar[i + 2].fillAmount = 1;

            yield return new WaitForSeconds(timeToFill);
        }

        dashBar[dashBar.Count - 1].fillAmount = 1;

        isVoiding = false;
    }
}
