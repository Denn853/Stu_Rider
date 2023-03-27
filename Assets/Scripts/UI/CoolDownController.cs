using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class CoolDownController : MonoBehaviour
{
    public static CoolDownController instance { get; private set; }

    public List<Button> abilities = new List<Button>();

    private void Awake()
    {
        instance = this;
    }

    public void CoolDown(int ability)
    {
        abilities[ability].image.color = Color.gray;
    }

    public void ComeBack(int ability, float coolDown)
    {
        abilities[ability].image.color = Color.white;
    }


}
