using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jackHP : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HP healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth < 0)
        {
            GameManager.Instance.LoseGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rat"))
        {
            TakeDamage(5);
        }
        if (collision.gameObject.CompareTag("Rat King"))
        {
            TakeDamage(10);
        }
    }

}
