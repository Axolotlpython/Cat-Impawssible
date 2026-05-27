using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDeath : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Yarn"))
        {
            audioSource.Play();
            Destroy(gameObject);

        }
    }
}
