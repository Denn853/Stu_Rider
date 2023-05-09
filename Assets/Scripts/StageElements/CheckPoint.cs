using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource checkPointSoundEffect;

    [Header("Respawn Options")]
    [SerializeField] private HorizontalMovementDHM hm;
    [SerializeField] private float time;
    [SerializeField] private Timer timer;

    Animator anim;



    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkPointSoundEffect.Play();

        time = timer.GetTimeRemaining();
        hm.CheckPoint(transform.position);
        hm.CheckPointTime(time);

        anim.SetTrigger("isActive");
    }

}
