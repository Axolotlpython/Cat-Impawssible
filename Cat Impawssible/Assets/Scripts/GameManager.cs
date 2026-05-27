using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text chessetext;
    public GameObject winPanel;
    public GameObject losePanel;

    private bool gameOver = false;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateChesseUI()
            if (winPanel != null)
        {
            winPanel .SetActive(false);
        }
            if (losePanel != null)
        {
            losePanel .SetActive(false);
        }
    }

    public void AddChesse(int amount)
    {
        if (gameOver) return;

        chesseCollected += amount;
        Update
    }
}
