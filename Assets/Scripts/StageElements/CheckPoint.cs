using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource checkPointSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkPointSoundEffect.Play();  

        PlayerController.instance.CheckPoint(transform.position);
    }
}
