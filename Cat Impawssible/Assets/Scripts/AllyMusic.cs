using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMusic : MonoBehaviour
{
    AudioSource audioSource;
    public float fade = 1.0f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.volume = 1.0f;
            audioSource.Play();
            StartCoroutine(FadeInAudio());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeOutAudio());
        }
    }

    private IEnumerator FadeOutAudio()
    {
        float startVolume = audioSource.volume;


        for (float t = 0; t < fade; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fade);
            yield return null;
        }


        audioSource.volume = 0;
        audioSource.Stop();
    }

    private IEnumerator FadeInAudio()
    {
        for (float t = 0; t < fade; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, 1.0f, t / fade);
            yield return null;
        }
        audioSource.volume = 1.0f;
    }
}
