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

    private void Start()
    {

        timeToVoid = dash.dashingTime / (200 * dashBar.Count);
        timeToFill = dash.coolDownTime / (200 * dashBar.Count);

    }

    private void Update()
    {
        if (!dash.canDash)
        {
            VoidBar();
        }

        if (dash.cooldown)
        {
            StartCoroutine(FillBar());
        } 
    }

    void VoidBar()
    {
        for (int i = dashBar.Count - 1; i >= 0; i--)
        {
            dashBar[i].fillAmount = -1;
        }
    }


    IEnumerator FillBar()
    {

        yield return new WaitForSeconds(timeToVoid);

        for (int i = 0; i <= dashBar.Count - 2; i += 3)
        {
            dashBar[i].fillAmount = 1;
            dashBar[i + 1].fillAmount = 1;
            dashBar[i + 2].fillAmount = 1;

            yield return new WaitForSeconds(timeToFill);
        }

        dashBar[dashBar.Count - 1].fillAmount = 1;

    }
}
