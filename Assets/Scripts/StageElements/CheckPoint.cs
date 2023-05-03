using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource checkPointSoundEffect;
    [SerializeField] private HorizontalMovementDHM hm;

    Animator anim;



    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkPointSoundEffect.Play();  

        hm.CheckPoint(transform.position);

        anim.SetTrigger("isActive");
    }
}
