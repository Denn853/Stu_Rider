using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalButton : MonoBehaviour
{
    private bool isPressed = false;

    public GameObject LavaRising;

    public AudioClip music;

    public AudioClip buttonSound;

    private AudioSource audioSource;

    public LayerMask playerLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        LavaRising.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = buttonSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isPressed)
        {
            isPressed = true;

            if (isPressed)
            {
                audioSource.Play();

                // Reproducir música
                audioSource.clip = music;
                audioSource.Play();


                LavaRising.SetActive(true);
            }
        }
    }
}
