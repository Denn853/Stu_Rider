using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKill : MonoBehaviour
{
    [Header("Scene to Load")]
    [SerializeField] public string scene;

    [Header("Player Animator")]
    [SerializeField] private Animator anim;
    [SerializeField] private HorizontalMovementDHM hm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DealDamageCorrutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(DealDamageCorrutine());
    }

    IEnumerator DealDamageCorrutine()
    {

        LevelController.instance.TakeDamage();

        Debug.Log(LevelController.instance.GetLifes());

        if (LevelController.instance.GetLifes() <= 0)
        {
            anim.SetTrigger("isDeath");
            yield return new WaitForSeconds(2);

            GameManager.instance.SubstractLife();
            SceneManager.LoadScene(scene, LoadSceneMode.Single);

            yield return null;
        } 
        else
        {
            anim.SetTrigger("isHurt");
            yield return new WaitForSeconds(0.75f);

            hm.Respawn();

            yield return null;
        }
    }
}
