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

    [Header("Camera Shake")]
    public CameraShake cam;
    public float duration;
    public float magnitude;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DealDamageCorrutine());
        StartCoroutine(cam.Shake(duration, magnitude));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(DealDamageCorrutine());
        StartCoroutine(cam.Shake(duration, magnitude));
    }

    IEnumerator DealDamageCorrutine()
    {
        hm.enabled = false;

        LevelController.instance.TakeDamage();

        Debug.Log(LevelController.instance.GetLifes());

        if (LevelController.instance.GetLifes() <= 0)
        {
            anim.SetTrigger("isDeath");
            yield return new WaitForSeconds(2);

            GameManager.instance.SubstractLife();

            if (GameManager.instance.GetLifes() <= 0)
            { 
                GameManager.instance.lifes = 3;
                Time.timeScale = 0;
                loseMenu.SetActive(true);


                yield return null;
            }
            else
            {
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);

                yield return null;
            }
        } 
        else
        {
            anim.SetTrigger("isHurt");
            yield return new WaitForSeconds(0.75f);

            hm.enabled = true;
            hm.Respawn();

            yield return null;
        }
    }
}
