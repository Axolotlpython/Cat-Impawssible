using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackHitSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlayingSound = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
   
        if (collision.gameObject.CompareTag("Rat") && !isPlayingSound)
        {
            StartCoroutine(PlaySoundUntilDone());
        }
        if (collision.gameObject.CompareTag("Rat King") && !isPlayingSound)
        {
            StartCoroutine(PlaySoundUntilDone());
        }
    }

    private IEnumerator PlaySoundUntilDone()
    {
        isPlayingSound = true; 
        audioSource.Play();   

        
        yield return new WaitUntil(() => !audioSource.isPlaying);

        isPlayingSound = false; 
    }
}

