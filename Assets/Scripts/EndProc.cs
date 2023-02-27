using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndProc : MonoBehaviour
{
    public bool passed = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            passed = true;
            SceneManager.LoadScene("EndOfStage");
        }
    }
}