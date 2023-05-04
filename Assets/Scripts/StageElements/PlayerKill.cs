using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKill : MonoBehaviour
{

    [Header("Lose Menu")]
    public GameObject loseMenu;

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

            if (GameManager.instance.GetLifes() <= 0)
            {
                switch (LevelController.instance.GetCurrentLevel())
                {
                    case "Level 1":
                        if (GameManager.instance.level < 2)
                            GameManager.instance.level = 2;
                        break;

                    case "Level 2":
                        if (GameManager.instance.level < 3)
                            GameManager.instance.level = 3;
                        break;

                    case "Level 3":
                        if (GameManager.instance.level < 4)
                            GameManager.instance.level = 4;
                        break;

                    case "Level 4":
                        if (GameManager.instance.level < 5)
                            GameManager.instance.level = 5;
                        break;
                }

                loseMenu.SetActive(true);

                yield return null;
            }
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);

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
