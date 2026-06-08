using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePickSound : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isPlayingSound = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chesse") && !isPlayingSound)
        {
            StartCoroutine(PlaySoundUntilDone());
        }
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Chesse") && !isPlayingSound)
        {
            StartCoroutine(PlaySoundUntilDone());
        }
    }*/



    private IEnumerator PlaySoundUntilDone()
    {
        isPlayingSound = true;
        audioSource.Play();


        yield return new WaitUntil(() => !audioSource.isPlaying);

        isPlayingSound = false;
    }
}

