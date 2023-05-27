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
    private bool isFilling = false;
    private bool isVoiding = false;

    private void Start()
    {

        timeToVoid = dash.dashingTime / (500 * dashBar.Count);
        timeToFill = dash.coolDownTime / dashBar.Count;

        Debug.Log("timeToVoid: " + timeToVoid);
        Debug.Log("timeToFill: " + timeToFill);

    }

    private void Update()
    {
        if (!dash.canDash && !isVoiding)
        {
            VoidBar();
        }

        if (dash.cooldown && !isFilling && isVoiding)
        {
            StartCoroutine(FillBar());
        }

        isFilling = false;
    }

    void VoidBar()
    {
        for (int i = dashBar.Count - 1; i >= 0; i--)
        {
            dashBar[i].fillAmount = -1;
        }
        
        isVoiding = true;
    }


    IEnumerator FillBar()
    {
        isFilling = true;

        float fillIncrement = 1f / dashBar.Count;
        float currentFill = 0f;

        yield return new WaitForSeconds(timeToVoid);

        for (int i = 0; i < dashBar.Count; i++)
        {
            float targetFill = currentFill + fillIncrement;
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime / timeToFill;
                dashBar[i].fillAmount = 1; //Establecer el sprite completo
            }

            yield return null;
            currentFill += targetFill;

        }

        isVoiding = false;
    }
}
