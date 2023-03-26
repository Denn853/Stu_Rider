using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{

    public List<GameObject> lifes = new List<GameObject>();

    public void ReceiveDamage()
    {
        lifes[GameManager.instance.lifes].GetComponent<Animator>().SetTrigger("ReceiveDamage");
    }
}
