using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKill : MonoBehaviour
{
    [Header("Scene to Load")]
    [SerializeField] private string scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(DealDamageCorrutine());
    }

    IEnumerator DealDamageCorrutine()
    {
        GetComponent<CircleCollider2D>().enabled = false;

        LevelController.instance.TakeDamage();

        if (LevelController.instance.GetLifes() <= 0)
        {
            PlayerController.instance.GetComponent<Animator>().SetTrigger("isDeath");
            yield return new WaitForSeconds(2);

            GameManager.instance.SubstractLife();
            SceneManager.LoadScene("Level_1", LoadSceneMode.Single);

            GetComponent<CircleCollider2D>().enabled = true;

            yield return null;
        } 
        else
        {
            PlayerController.instance.GetComponent<Animator>().SetTrigger("isHurt");
            yield return new WaitForSeconds(0.75f);

            PlayerController.instance.Respawn();

            GetComponent<CircleCollider2D>().enabled = true;

            yield return null;
        }
    }
}
