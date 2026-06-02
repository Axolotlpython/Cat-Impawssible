using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessepoint : MonoBehaviour
{
    public int value = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddCheese(value);
            Destroy(gameObject);
        }
    }
}
