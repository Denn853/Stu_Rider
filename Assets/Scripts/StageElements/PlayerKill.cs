using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKill : MonoBehaviour
{
    [Header("Scene to Load")]
    [SerializeField] public string scene;

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

        if (LevelController.instance.GetLifes() <= 0)
        {
            PlayerController.instance.GetComponent<Animator>().SetTrigger("isDeath");
            yield return new WaitForSeconds(2);

            GameManager.instance.SubstractLife();
            SceneManager.LoadScene(scene, LoadSceneMode.Single);

            yield return null;
        } 
        else
        {
            PlayerController.instance.GetComponent<Animator>().SetTrigger("isHurt");
            yield return new WaitForSeconds(0.75f);

            PlayerController.instance.Respawn();

            yield return null;
        }
    }
}
